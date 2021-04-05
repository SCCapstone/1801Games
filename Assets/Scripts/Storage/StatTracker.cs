using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
    int spikes, totalCoins, speed, invincibility, health;
    public static StatTracker instance;
    int[] Stats  = new int [5];
    // Retrieve Stats from Player Prefs
    private void Awake()
    {
        instance = this;

        if(PlayerPrefs.HasKey("spikes"))
        {
            spikes = PlayerPrefs.GetInt("spikes", 0);
        }

        if (PlayerPrefs.HasKey("totalCoins"))
        {
            totalCoins = PlayerPrefs.GetInt("totalCoins", 0);
        }

        if (PlayerPrefs.HasKey("speed"))
        {
            speed = PlayerPrefs.GetInt("speed", 0);
        }

        if (PlayerPrefs.HasKey("invincibility"))
        {
            invincibility = PlayerPrefs.GetInt("invincibility", 0);
        }

        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health", 0);
        }

        createArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

        //Creates Initial Array
    public void createArray()
    {
        int[] Stats = { spikes, totalCoins, speed, invincibility, health};
        this.Stats = Stats;
    }

    //Allows for the array to be returned
    public int[] getArray()
    {
        createArray();
        return this.Stats;

    }

    //Update Stats After Death
    public void updateStats(int newSpikes, int newCoins, int newSpeed, int newInvincibility, int newHealth)
    {
        //Add new Stats
        spikes += newSpikes;
        totalCoins += newCoins;
        speed += newSpeed;
        invincibility += newInvincibility;
        health += newHealth;

        //Save Stats
        PlayerPrefs.SetInt("spikes", spikes);
        PlayerPrefs.SetInt("totalCoins", totalCoins);
        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.SetInt("invincibility", invincibility);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }

    //Resets all stats in Player Prefs
    public void reset()
    {
        if(PlayerPrefs.HasKey("spikes"))
        {
            PlayerPrefs.SetInt("spikes", 0);
            PlayerPrefs.SetInt("totalCoins", 0);
            PlayerPrefs.SetInt("speed", 0);
            PlayerPrefs.SetInt("invincibility", 0);
            PlayerPrefs.SetInt("health", 0);

            spikes = 0;
            totalCoins = 0;
            speed = 0; 
            invincibility = 0;
            health = 0;

            PlayerPrefs.Save();
        }
    }
}
