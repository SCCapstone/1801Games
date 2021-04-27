﻿// Classes Jump, OnTriggerEnter2D Written By Bradley Williamson
// Jump, OnTriggerEnter2D modified by DaVonte Blakely
// Boost Class edited by Davonte Blakely
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Dev_Move : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle;
    public float defaultSpeed = 9;
    //player speed
    public float moveSpeed;
    // bool check to see if player is on the ground
    public bool isGrounded = false;
    //jump height
    public float jumpHeight = 15.6f;
    public int jumps = 0;
    // Coin value
    public int coinValue = 1;
    // for speed boost
    public float boostTimer = 4;
    public float temp = 0;
    public bool boost;
    public float boostSpeed = 12f;
    public TextMeshProUGUI SpeedBoostText;
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
    void Start()
    {
    // intiates boost and its timer
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        animator = GetComponent<Animator>();
        moveSpeed = defaultSpeed;
        boostTimer = 0;
        boost = false;
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        ConstantMove();
        //calls jump check
        Jump();
        //calls boost check
        Boost();
        //calls dash check
        Dash();    
    
    }

    void ConstantMove()
    {
        Vector3 movement = Vector3.right;
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Boost()
    {
        if(boost)
        {
            moveSpeed = boostSpeed;
            temp += Time.deltaTime;
            SpeedBoostText.text = Mathf.Ceil(boostTimer).ToString() + "s";
            // reset boost
            if(Mathf.Floor(temp) == 1)
            {
                boostTimer -= temp;
                temp = 0;

            }

            if(boostTimer < 0)
            {
                boostTimer = 4;
                moveSpeed = defaultSpeed;
                boost = false;
                SpeedBoostText.text = "";
            }
        }
    }

    void Slow()
    {
        if(slow)
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
        if(dashing)
        {
            moveSpeed = dashSpeed;
            dashTimer += Time.deltaTime;
            if(dashTimer >= .02)
            {
                dashTimer = 0;
                moveSpeed = defaultSpeed;
                dashing = false;
            }
        }
    }
    void Jump()
    {
        if(jumps >= 3 )
        {
            dashing = true;
            jumps = 0;
            isGrounded = true;
            return;
        }
        //TouchPhase.Began
        // if button down and player is grounded
        if(Input.touchCount == 1) {

            if((Input.GetTouch(0).phase == TouchPhase.Began) && (isGrounded == true))
            {
                if(Input.GetTouch(0).position.x < (Screen.width/2) && Input.GetTouch(0).position.y < (Screen.height * .90))
                {
                    if(jumps <= 2)
                    {
                        animator.SetBool("isJumping", true);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                        jumps++;
                        collectParticle.Play();
                        FindObjectOfType<AudioManager>().Play("Jump");
                    }

                }
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
        // jump
            if(jumps <= 2)
            {
                animator.SetBool("isJumping", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                jumps++;
                collectParticle.Play();
                FindObjectOfType<AudioManager>().Play("Jump");
                
            }
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
        }
        // if collison with gem destroy gem set move speed and boost true
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            boostTimer = 4;
            boost = true;
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            isGrounded = true;
            jumps=0;
            
        }
        if(other.gameObject.CompareTag("Crystal"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Slow"))
        {
            Destroy(other.gameObject);
            slow = true;
        }
        if(other.gameObject.CompareTag("RockPickup"))
        {
            Destroy(other.gameObject);
        }
    }
}

