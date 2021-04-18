/*
 * Written by Tariq Scott,DaVonte Blakely, Yiqian Sun, Nick Bautista
 * Player.cs tracks the players health
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
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
    public StatTracker statTracker;

    //variable for player flashes
    private bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer playerSprite;
    
    //Variables For Stats 
    public int spikesHit;
    public int totalCoins;
    public int speedBoost;
    public int invincibilityGems;
    public int healthPotionsCollected;
    //End Variables For Stats

    public Score score;
    float temp = 0;
    public bool invincible;
    public TextMeshProUGUI invincibilityText;
    public TextMeshProUGUI numRocksText;
    public float timer = 7;
    public int numRocks;
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject floatingTextprefab;
    /*
     * Start gives the player full health when the game first starts. 
       It also sets the visual health bar at max health, which is 100.
    */
    public void Start() 
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        numRocks = 10;
        numRocksText.text = numRocks.ToString();
        Time.timeScale = 1f;
        spikesHit = 0;
        totalCoins = 0;
        speedBoost = 0;
        invincibilityGems = 0;
        healthPotionsCollected = 0;
        playerSprite = GetComponent<SpriteRenderer>();
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
        isFlashing();
    }

    void isFlashing()
    {
        if(flashActive)
        {
            if(flashCounter > flashLength * .66f)
            {
               playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    //Code for Invinciblity Status
    void IsInvincible()
    {
        if(invincible == true)
        {
	        playerSprite.color = new Color(playerSprite.color.r, 0.5f, playerSprite.color.g, playerSprite.color.b);
            temp += Time.deltaTime;
            invincibilityText.text = Mathf.Ceil(timer).ToString() + "s";
            if(Mathf.Floor(temp) == 1)
            {
                timer -= temp;
                temp = 0;

            }
            if(timer < 0)
            {
                invincible = false;
                timer = 7;
                invincibilityText.text = "";
            }
        }
        else
        {
            playerSprite.color = new Color(playerSprite.color.r, 1f, playerSprite.color.g, playerSprite.color.b);
        }
    }

    public void addRock()
    {

            numRocks+= 5;
            numRocksText.text = numRocks.ToString();
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
            statTracker.updateStats(spikesHit,totalCoins,speedBoost,invincibilityGems,healthPotionsCollected);
        }
 
    }

    
    //Code for throwing rocks
    public void ThrowRock()
    {
        //Add Touch Controls
        if(Input.touchCount > 0 && numRocks > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
               if(Input.GetTouch(0).position.x > (Screen.width/2) && Input.GetTouch(0).position.y < (Screen.height * .90))
               {
                    var playerPos = GameObject.Find("Player").transform.position;
                    playerPos.Set(playerPos.x + 1, playerPos.y + 1,playerPos.z);
                    var newRock = Instantiate(rock,playerPos,Quaternion.identity);
                    Destroy(newRock,2f);
                    numRocks--;
                    numRocksText.text = numRocks.ToString();
                }

            }
        }


        if(Input.GetButtonDown("Throw") && numRocks > 0)
        {
            var playerPos = GameObject.Find("Player").transform.position;
            playerPos.Set(playerPos.x + 1, playerPos.y + 1,playerPos.z);
            var newRock = Instantiate(rock,playerPos,Quaternion.identity);
            Destroy(newRock,2f);
            FindObjectOfType<AudioManager>().Play("Rock");
            numRocks--;
            numRocksText.text = numRocks.ToString();
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
        //ShowDamage(Damage.ToString());
            CurrentHealth -= Damage;
            healthBar.SetHealth(CurrentHealth);

            flashActive = true;
            flashCounter = flashLength;
    }

    void ShowDamage(string text)
    {
        GameObject prefab = Instantiate(floatingTextprefab, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = text;
    }
    void giveHealth(int health)
    {
        CurrentHealth += health;
        healthBar.SetHealth(CurrentHealth);
        /***CHEAT MODDE***/
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            int i = 0;
            while(i <= 1001) {
                CurrentHealth += i;
                i++;
            }
        }
        /***CHEAT MODE ENDS***/
    }

    //Player interactions with other objects
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            if(invincible == false)
            {
                TakeDamage(20);
                FindObjectOfType<AudioManager>().Play("Hit");
            }
            spikesHit++;
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
            healthPotionsCollected++;
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
        if (other.gameObject.CompareTag("Bullet"))
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
            invincibilityGems++;
            Destroy(other.gameObject);
            timer = 7;
            invincible = true;
        }
    }
}
