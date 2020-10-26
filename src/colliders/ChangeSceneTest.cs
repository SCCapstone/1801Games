using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTest : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene("MAIN SCENE");
            HighScoreBoard.instance.CompareScore(Score.instance.returnScore());
        }
    }


}
