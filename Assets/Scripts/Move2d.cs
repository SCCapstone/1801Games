// Classes Jump, OnTriggerEnter2D Written By Bradley Williamson

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Move2d : MonoBehaviour
{

    public ScoreManager scoreManager;
    //player speed
    public float moveSpeed = 5f;
    // bool check to see if player is on the ground
    public bool isGrounded = false;
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
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);//Vector3.right;
        transform.position += movement * Time.deltaTime * moveSpeed;
        // speed boost check if boost is true
        if(boost)
        {
        // add 1 to boost timer
            boostTimer += Time.deltaTime;
            // reset boost
            if(boostTimer >= 5)
            {
                moveSpeed = 5f;
                boostTimer = 0;
                boost = false;
            }
        }
    }

  

    void Jump()
    {
        // if button down and player is grounded
        if(Input.touchCount > 0) {
            if(Input.GetTouch(0).phase == TouchPhase.Began && isGrounded == true)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
        // jump
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            isGrounded = false;
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
            scoreManager.checkScore(Score.instance.returnScore());
        }
        // if collison with gem destroy gem set move speed and boost true
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            moveSpeed = 10f;
            boost = true;
        }
    }
}
