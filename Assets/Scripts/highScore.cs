using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System;

public class highScore : MonoBehaviour
{
    public static highScore instance;
    public TextMeshProUGUI text;
    int highS;
    int num = 0;
    public String[] board = {"Player                                                  7",
                             "Player                                                  6",
                             "Player                                                  5",
                             "Player                                                  4",
                             "Player                                                  3"};
   
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < board.Length; i++)
        {
            text.text = text.text + board[i] + "\n";
        }


    }

    // Update is called once per frame
    void Update()
    {
        //text.text = num.ToString();


        num++;


    }

    public void ChangehighScore(int coinValue)
    {
        highS += coinValue;
        text.text = "1." + highS.ToString();
    }
 
   
}
