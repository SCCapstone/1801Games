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

public class HighScoreBoard : MonoBehaviour
{
    public static HighScoreBoard instance;
    public ScoreManager scoreManager;
    
    public TextMeshProUGUI text;
    int[] Highscores = new int[5];
 
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
    public String[] printScores() // Gett array of high scores as string array
    {
        text.text = "";
        Highscores = scoreManager.getArray(); 
        String[] scores = new string[Highscores.Length];
        for(int i = 0; i < Highscores.Length; i++)
        {
            text.text = text.text +  " Score " + (i+1).ToString() + "                                          " + Highscores[i].ToString() + "\n";
        }

        return scores;
    }

    // Update is called once per frame
    void Update()
    {
        printScores();
    }
}
