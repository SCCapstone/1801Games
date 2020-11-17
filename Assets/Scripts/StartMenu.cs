using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject StartMenuUI;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    //loads Start Menu
    public void LoadGame() {
        string MainScreen = "MAIN SCENE";
        SceneManager.LoadScene(MainScreen);
    }
    // loads highscores
    public void LoadHighScores() {
        string MainScreen = "highscores";
        SceneManager.LoadScene(MainScreen);
    }
    // settings
    public void LoadSettings() {
        string MainScreen = "SettingsScreen";
        SceneManager.LoadScene(MainScreen);
    }
    public void LoadQuit() {
        Application.Quit();
    }

    
}
