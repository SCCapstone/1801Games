using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
// Classes Jump, OnTriggerEnter2D Written By Bradley Williamson
public class Move2d : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public float boostTimer;
    public bool boost;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        boostTimer = 0;
        boost = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        if(boost)
        {
            boostTimer += Time.deltaTime;
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
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            moveSpeed = 10f;
            boost = true;
            
        }
        /*if (other.gameObject.CompareTag("Crystal") && bool alive)
        {
            //Destory()
            //SceneManager.LoadScene("highscores");
        }
        */
    }
}
