using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//WRITTEN BY BRADLEY WILLIAMSON
public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI text;
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
        score += coinValue;
        text.text = "X" + score.ToString();
    }

    public int returnScore()
    {
        return score;
    }
}

