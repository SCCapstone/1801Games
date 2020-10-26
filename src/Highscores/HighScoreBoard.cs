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
    public int[] Highscores = new int[5];
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
    //Score from game is compared to the highscore board scores
    public void CompareScore(int score)
    {
        int[] Highscores = instance.Highscores;
        for (int i = 0; i < Highscores.Length; i++)
        {
            Highscores[i] = i;
        }

        if (score > Highscores[(Highscores.Length) - 1])
        {
            Highscores[Highscores.Length - 1] = score;
            text.text = "New Highscore! " + Highscores[Highscores.Length - 1].ToString(); // Notify user of new high score
        }


        else { 
            for (int i = 0; i < Highscores.Length - 1; i++)
            {
             if (score > Highscores[i]) //if a highscore is obtained      
             {
                Highscores[i] = score;
                text.text = "Score on the Board! " + Highscores[i].ToString(); // Notify user of new high score
                break; //End Loop
             }
            }
        }
        
    }

    public String[] getScores() // Gett array of high scores as string array
    {
        String[] scores = new string[Highscores.Length];
        for(int i = 0; i < Highscores.Length; i++)
        {
            scores[i] = "Player " + i.ToString() + "           " + Highscores[i].ToString();
        }

        return scores;
    }




    // Update is called once per frame
    void Update()
    {

    }
}
