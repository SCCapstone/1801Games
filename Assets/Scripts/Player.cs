/*
 * Written by Tariq Scott,DaVonte Blakely, Bradley Williamson
 * Player.cs tracks the players health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int MaxHealth = 100; // The max health the player can have
    public int CurrentHealth; // The current health the player has
    public GameObject pauseMenuUI;
    public HealthBar healthBar;
    public ScoreManager scoreManager;
    public Score score;
    float temp = 0;
    public bool invincible;
    public TextMeshProUGUI text;
    public float timer = 7;
    [SerializeField] private GameObject rock;
    /*
     * Start gives the player full health when the game first starts. 
       It also sets the visual health bar at max health, which is 100.
    */
    public void Start() 
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        Time.timeScale = 1f;
    }
    
    /*
        Update makes the player take damage. 20 in this case.
        P is a placeholder to make the player take temporary damage.
    */
    void Update() 
    {
        Dead();
        IsInvincible();
        ThrowRock();
    }

    //Code for Invinciblity Status
    void IsInvincible()
    {
        if(invincible == true)
        {
            temp += Time.deltaTime;
            text.text = Mathf.Ceil(timer).ToString() + "s";
            if(Mathf.Floor(temp) == 1)
            {
                timer -= temp;
                temp = 0;

            }
            if(timer < 0)
            {
                invincible = false;
                timer = 7;
                text.text = "";
            }
        }
    }

    
    //On Death Checks
    void Dead() 
    {
        if (CurrentHealth <= 0)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;

            //Check to see if a high score is achieved
            CurrentHealth = 100;
            scoreManager.checkScore(score.returnScore());
            CurrentHealth = 100;
        }
 
    }

    
    //Code for throwing rocks
    public void ThrowRock()
    {
        //Add Touch Controls
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
               if(Input.GetTouch(0).position.x > (Screen.width/2))
               {
                    var playerPos = GameObject.Find("Player").transform.position;
                    playerPos.Set(playerPos.x + 1, playerPos.y + 1,playerPos.z);
                    var newRock = Instantiate(rock,playerPos,Quaternion.identity);
                    Destroy(newRock,2f);
                    
                }

            }
        }


        if(Input.GetButtonDown("Throw"))
        {
            var playerPos = GameObject.Find("Player").transform.position;
            playerPos.Set(playerPos.x + 1, playerPos.y + 1,playerPos.z);
            var newRock = Instantiate(rock,playerPos,Quaternion.identity);
            Destroy(newRock,2f);
            FindObjectOfType<AudioManager>().Play("Rock");
        }

    }

    /*
      Damages subtracts damage from the player.
      Health with go from 100, to 80, 60 all the
      way to zero. The visual health bar is 
      updated as well. 
    */
    public void TakeDamage(int Damage)
    {
            CurrentHealth -= Damage;
            healthBar.SetHealth(CurrentHealth);
    }
    void giveHealth(int health)
    {
        CurrentHealth += health;
        healthBar.SetHealth(CurrentHealth);
        /***CHEAT MODE***/
        if (Input.GetKeyUp(KeyCode.Backslash)) {
            int i = 100;
            while (i == 100) {
                CurrentHealth += i;
                i++;
            }
        }
        /***CHEAT MODE END***/
    }

    //Player interactions with other objects
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            if(invincible == false)
            {
                TakeDamage(25);
                FindObjectOfType<AudioManager>().Play("Hit");
            }
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Potion"))
        {
            giveHealth(20);
            if(invincible == false)
            {
                if(CurrentHealth > 100)
                {
                    CurrentHealth = 100;
                }
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(invincible == false)
            {
                TakeDamage(10);
                FindObjectOfType<AudioManager>().Play("Hit");
            }           
        }
        if(other.gameObject.CompareTag("Floor"))
        {
          TakeDamage(CurrentHealth);
        }
        if(other.gameObject.CompareTag("Invincibility"))
        {
            //Add Particles
            Destroy(other.gameObject);
            timer = 7;
            invincible = true;
        }
    }
}
