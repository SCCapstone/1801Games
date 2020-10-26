using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScore : MonoBehaviour
{
    public static highScore instance;
    public TextMeshProUGUI text;
    int highS;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangehighScore(int coinValue)
    {
        highS += coinValue;
        text.text = "1." + highS.ToString();
    }
 
   
}
