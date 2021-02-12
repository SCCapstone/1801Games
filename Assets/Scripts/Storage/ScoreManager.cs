// Written by DaVonte Blakely

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int highScore1, highScore2, highScore3, highScore4, highScore5;
    
    int[] HighScore = new int[5];



    //Retrieves HighScores from Player Prefs
    private void Awake()
    {
        instance = this;


        if(PlayerPrefs.HasKey("HighScore1"))
        {
            highScore1 = PlayerPrefs.GetInt("HighScore1", 0);
        }

        if (PlayerPrefs.HasKey("HighScore2"))
        {
            highScore2 = PlayerPrefs.GetInt("HighScore2", 0);
        }

        if (PlayerPrefs.HasKey("HighScore3"))
        {
            highScore3 = PlayerPrefs.GetInt("HighScore3", 0);
        }

        if (PlayerPrefs.HasKey("HighScore4"))
        {
            highScore4 = PlayerPrefs.GetInt("HighScore4", 0);
        }

        if (PlayerPrefs.HasKey("HighScore5"))
        {
            highScore5 = PlayerPrefs.GetInt("HighScore5", 0);
        }

        createArray();
    }

    void Start()
    {
        
    }

    //Creates Initial Array
    public void createArray()
    {
        int[] HighScore = {highScore1, highScore2, highScore3, highScore4, highScore5};
        this.HighScore = HighScore;
    }

    //Allows for the array to be returned
    public int[] getArray()
    {
        createArray();
        
        return this.HighScore;

    }

    void Update()
    {

    }




    //Checks score to see if high score is earned
    public void checkScore(int score)
    {

            if (score > PlayerPrefs.GetInt("HighScore1", 0))
            {
                int temp = PlayerPrefs.GetInt("HighScore1", 0);
                PlayerPrefs.SetInt("HighScore1", score);
                PlayerPrefs.Save();
                checkScore(temp);

            }

            else if (score > PlayerPrefs.GetInt("HighScore2", 0))
            {
                int temp = PlayerPrefs.GetInt("HighScore2", 0);
                PlayerPrefs.SetInt("HighScore2", score);
                PlayerPrefs.Save();
                checkScore(temp);
        }

            else if (score > PlayerPrefs.GetInt("HighScore3", 0))
            {
                int temp = PlayerPrefs.GetInt("HighScore3", 0);
                PlayerPrefs.SetInt("HighScore3", score);
                PlayerPrefs.Save();
                checkScore(temp);
            }

            else if (score > PlayerPrefs.GetInt("HighScore4", 0))
            {
                int temp = PlayerPrefs.GetInt("HighScore4", 0);
                PlayerPrefs.SetInt("HighScore4", score);
                PlayerPrefs.Save();
                checkScore(temp);
            }

            else if (score > PlayerPrefs.GetInt("HighScore5", 0))
            {
                int temp = PlayerPrefs.GetInt("HighScore5", 0);
                PlayerPrefs.SetInt("HighScore5", score);
                PlayerPrefs.Save();
                checkScore(temp);
            }


    }


    //For Player to reset stats
    public void reset()
    {
        //Reset Score in Storage
        if(PlayerPrefs.HasKey("HighScore1"))
        {
            PlayerPrefs.SetInt("HighScore1", 0);
            PlayerPrefs.SetInt("HighScore2", 0);
            PlayerPrefs.SetInt("HighScore3", 0);
            PlayerPrefs.SetInt("HighScore4", 0);
            PlayerPrefs.SetInt("HighScore5", 0);

            highScore1 = 0;
            highScore2 = 0;
            highScore3 = 0;
            highScore4 = 0;
            highScore5 = 0;

            PlayerPrefs.Save();
        }

    }
}
