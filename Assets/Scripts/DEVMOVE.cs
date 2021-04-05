// Written by Tariq Scott
// Edited by Bradley Williamson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEVMOVE : MonoBehaviour
{

    [SerializeField] ParticleSystem collectParticle;
    public ScoreManager scoreManager;
    public float defaultSpeed = 9;
    //player speed
    public float moveSpeed;
    public float speed = 3;
    // bool check to see if player is on the ground
    public bool isGrounded = false;
    //jump height
    public float jumpHeight = 15.6f;
    public int jumps = 0;
    // Coin value
    public int coinValue = 1;
    // for speed boost
    public float boostTimer = 0;
    public bool boost;
    public float boostSpeed = 12f;


    public Animator animator;
    public Vector3 dash = Vector3.right;
    public bool dashing = false;
    public float dashSpeed = 200f;
    public float dashTimer = 0;
    // for slowdown
    public bool slow;
    public float slowTimer = 0;
    public float slowSpeed = 6f;
    // Start is called before the first frame update
    //public Rigidbody2d rb;
  
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        moveSpeed = defaultSpeed;
        boostTimer = 0;
        boost = false;
    }

    void Slow()
    {
        if (slow)
        {
            moveSpeed = slowSpeed;
            slowTimer += Time.deltaTime;
            if (slowTimer >= 3)
            {
                slowTimer = 0;
                moveSpeed = defaultSpeed;
                slow = false;
            }
        }
    }

    void Dash()
    {
        if (dashing)
        {
            moveSpeed = dashSpeed;
            dashTimer += Time.deltaTime;
            if (dashTimer >= .02)
            {
                dashTimer = 0;
                moveSpeed = defaultSpeed;
                dashing = false;
            }
        }
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        // if collision with coin destroy coin
        if (other.gameObject.CompareTag("Coin"))
        {
            
            Score.instance.ChangeScore(coinValue);
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
        // if collison with gem destroy gem set move speed and boost true
        if (other.gameObject.CompareTag("Gem"))
        {
            
            Destroy(other.gameObject);
            boost = true;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            isGrounded = true;
            jumps = 0;

        }
        if (other.gameObject.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Slow"))
        {
            Destroy(other.gameObject);
            slow = true;
        }
        if (other.gameObject.CompareTag("RockPickup"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<Player>().addRock();
        }
    }

    void Boost()
    {
        if (boost)
        {
            moveSpeed = boostSpeed;
            boostTimer += Time.deltaTime;
            // reset boost
            if (boostTimer >= 3)
            {
                boostTimer = 0;
                moveSpeed = defaultSpeed;
                boost = false;
            }
        }
    }

    void ConstantMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //moveDirection = new Vector2(moveX, moveY);
        if (Input.GetKey(KeyCode.UpArrow))
        {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed));
                        
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -speed));
           
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
        }


    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        ConstantMove();
        //calls jump check
        //Jump();
        //calls boost check
        Boost();
        //calls dash check
        Dash();

    }

   
}
