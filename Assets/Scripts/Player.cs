﻿/*
 * Written by Tariq Scott
 * Player.cs tracks the players health
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int MaxHealth = 100; // The max health the player can have
    public int CurrentHealth; // The current health the player has
    public GameObject pauseMenuUI;
    public HealthBar healthBar;
    public ScoreManager scoreManager;
    public Score score;

    /*
     * Start gives the player full health when the game first starts. 
       It also sets the visual health bar at max health, which is 100.
    */
    public void Start() {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        Time.timeScale = 1f;
    }
    
    /*
        Update makes the player take damage. 20 in this case.
        P is a placeholder to make the player take temporary damage.
    */
    void Update() {
        if (CurrentHealth <= 0)
        {
            Dead();
            CurrentHealth = 100;
        }
    }

    void Dead() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        //Check to see if a high score is achieved
        CurrentHealth = 100;
        scoreManager.checkScore(score.returnScore());
        
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
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            TakeDamage(100);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Potion"))
        {
            giveHealth(20);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);
        }
    }
   
}
