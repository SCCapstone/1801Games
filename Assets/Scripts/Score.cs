using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//WRITTEN BY BRADLEY WILLIAMSON
public class Score : MonoBehaviour
{

    // creates an instance of Score
    public static Score instance;
    // creates an instance of text mesh for the in game text
    public TextMeshProUGUI text;
    public Text playAgainText;
    // int for score
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }
    // Update is called once per frame
   public void ChangeScore(int coinValue)
    {
    // if change score is called update score and update text in game
        score += coinValue;
        text.text = score.ToString();
        playAgainText.text = score.ToString();
    }
    public int returnScore()
    {
        return score;
    }
}
