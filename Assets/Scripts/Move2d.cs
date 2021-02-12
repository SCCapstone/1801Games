// Classes Jump, OnTriggerEnter2D Written By Bradley Williamson
// Jump, OnTriggerEnter2D modified by DaVonte Blakely
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move2d : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle;
    public ScoreManager scoreManager;
    //player speed
    public float moveSpeed = 9f;
    // bool check to see if player is on the ground
    public bool isGrounded = false;
    //jump height
    public float jumpHeight = 15.6f;
    public int jumps = 0;
    // Coin value
    public int coinValue = 1;
    // for speed boost
    public float boostTimer;
    public bool boost;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    // intiates boost and its timer
        boostTimer = 0;
        boost = false;
    }

    // Update is called once per frame
    void Update()
    {
    // calls jump check
        Jump();
        // player movement
        Vector3 movement = Vector3.right;
        transform.position += movement * Time.deltaTime * moveSpeed;
        // speed boost check if boost is true
        if(boost)
        {
        // add 1 to boost timer
            boostTimer += Time.deltaTime;
            // reset boost
            if(boostTimer >= 5)
            {
                moveSpeed = 15f;
                boostTimer = 0;
                boost = false;
            }
        }
    }

  

    void Jump()
    {
        if(jumps >= 2)
        {
            jumps = 0;
            isGrounded = false;
            return;
        }
        //TouchPhase.Began
        // if button down and player is grounded
        if(Input.touchCount == 1) {

            if((Input.GetTouch(0).phase == TouchPhase.Began) && (isGrounded == true))
            {

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                if(jumps>=2)
                {
                    isGrounded = false;
                    jumps = 0;
                }
                jumps++;
                collectParticle.Play();
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
        // jump
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            if(jumps>=2)
            {
                isGrounded = false;
                jumps = 0;
            }
            jumps++;
            collectParticle.Play();
        }
    }
    // collison events
    public void OnTriggerEnter2D(Collider2D other)
    {
    // if collision with coin destroy coin
        if (other.gameObject.CompareTag("Coin"))
        {
            Score.instance.ChangeScore(coinValue);
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
            //scoreManager.checkScore(Score.instance.returnScore());
        }
        // if collison with gem destroy gem set move speed and boost true
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            moveSpeed = 10f;
            boost = true;
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumps=0;
        }
    }
}
