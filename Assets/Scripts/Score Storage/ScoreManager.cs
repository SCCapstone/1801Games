// Written by Tariq Scott

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int highScore1, highScore2, highScore3, highScore4, highScore5;
    
    int[] HighScore = new int[5];
    
    private void Awake()
    {
        instance = this;
               // PlayerPrefs.SetInt("HighScore2",13);
                highScore1 = PlayerPrefs.GetInt("HighScore1");
                highScore2 = PlayerPrefs.GetInt("HighScore2");
                highScore3 = PlayerPrefs.GetInt("HighScore3");
                highScore4 = PlayerPrefs.GetInt("HighScore4");
                highScore5 = PlayerPrefs.GetInt("HighScore5");
        
        instance.createArray();
    }

   



    void Start()
    {
      
    }

    public void createArray()
    {
        int[] HighScore = {highScore1, highScore2, highScore3, highScore4, highScore5};
        this.HighScore = HighScore;
    }

    public int[] getArray()
    {
        createArray();
        
        this.HighScore[0] = PlayerPrefs.GetInt("HighScore1");
        return this.HighScore;

    }

    void Update()
    {

    }


    //Checks score to see if high score is earned
    public void checkScore(int score)
    {
        for(int i = 0; i < HighScore.Length-1; i ++)
        {
            if(score > HighScore[i])
            {
                if((score < HighScore[i+1]) || (i+1 > HighScore.Length-1))
                {
                    HighScore[i] = score;
                    PlayerPrefs.SetInt("HighScore" + (i+1).ToString(), score);
                }
            }
        }
    }




    //For Player to reset stats
    public void reset()
    {

        PlayerPrefs.SetInt("HighScore1",0);
        PlayerPrefs.SetInt("HighScore2",0);
        PlayerPrefs.SetInt("HighScore3",0);
        PlayerPrefs.SetInt("HighScore4",0);
        PlayerPrefs.SetInt("HighScore5",0);

        highScore1 = 0;
        highScore2 = 0;
        highScore3 = 0;
        highScore4 = 0;
        highScore5 = 0;

        

    }
}
