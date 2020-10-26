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
    public int[] Highscores = { 7,7,7,7,7,7};
    public static HighScoreBoard instance;
    public TextMeshProUGUI text;
 
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    public void CompareScore(int score)
    {
      
        for(int i = 0; i < Highscores.Length; i++)
        {
            if(score > Highscores[i])
            {
                if((score < Highscores[i+1]) )
                {
                    Highscores[i] = score;
                    text.text = "New Highscore!";
                    //text.text = "Highscore: " + Highscores[i].ToString();
                    //SceneManager.LoadScene("highscores");

                    break;
                }
            }
        }
    }

    public String[] getScores()
    {
        String[] scores = new string[Highscores.Length];
        for(int i = 0; i < Highscores.Length; i++)
        {
            scores[i] = "Player " + i.ToString() + "           " + Highscores[i].ToString();
        }

        return scores;
    }

    public void printScores(String[] scores)
    {
        String board = " ";

        for(int i = 0; i < scores.Length; i++)
        {
            board = board + scores[i] + " \n";
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
