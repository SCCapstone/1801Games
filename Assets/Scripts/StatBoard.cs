/**
    DaVonte Blakely
**/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class StatBoard : MonoBehaviour
{
    public static StatBoard instance;
    public StatTracker statTracker;
    
    public TextMeshProUGUI text;
    int[] Stats = new int[5];
 
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        printScores();
    }



    //Returns the Array or "Board" of High Scores
    public void printScores() // Gett array of high scores as string array
    {
        text.text = "";
        Stats = statTracker.getArray(); 
        String[] tStats = new string[Stats.Length];
        text.text = text.text + "Spikes Hit"+ "                                             " + Stats[0].ToString() + "\n";
        text.text = text.text + "Total Coins"+ "                                           " + Stats[1].ToString() + "\n";
        text.text = text.text + "Speed Boost"+ "                                        " + Stats[2].ToString() + "\n";
        text.text = text.text + "Invincibility Gems"+ "                                 " + Stats[3].ToString() + "\n";
        text.text = text.text + "Health Potions"+ "                                      " + Stats[4].ToString() + "\n";
    }

    // Update is called once per frame
    void Update()
    {
        printScores();
    }
}
