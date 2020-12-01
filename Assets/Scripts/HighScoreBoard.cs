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

/*
    //Compares the pre-existing high scores to the score achieved. records if high score is achieved.
    public void CompareScore(int score)
    {
        for (int i = 0; i < Highscores.Length; i++)
        {
            Highscores[i] = i;
        }

        //Highest High Score case
        if (score > Highscores[(Highscores.Length) - 1])
        {
            Highscores[Highscores.Length - 1] = score;
            //text.text = "New Highscore! " + Highscores[Highscores.Length - 1].ToString(); // Notify user of new high score
        }

        //All other cases
        else { 
            for (int i = 0; i < Highscores.Length - 1; i++)
            {
             if (score > Highscores[i]) //if a highscore is obtained      
             {
                if(score < Highscores[i+1]) //Score is less than next highscore
                {
                    Highscores[i] = score;
                    //text.text = "Score on the Board! " + Highscores[i].ToString(); // Notify user of new high score
                    break; //End Loop
                }
             }
            }
        }
        
    }
*/

    //Returns the Array or "Board" of High Scores
    public String[] printScores() // Gett array of high scores as string array
    {
        Highscores = scoreManager.getArray(); 
        String[] scores = new string[Highscores.Length];
        for(int i = 0; i < Highscores.Length; i++)
        {
            text.text = text.text +  "Score " + (i+1).ToString() + "                                          " + Highscores[i].ToString() + "\n";
        }

        return scores;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
