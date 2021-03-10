// written by ?
// edited by Tariq Scott 
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
    // loads highscores screen
    public void LoadHighScores() {
        string MainScreen = "highscores";
        SceneManager.LoadScene(MainScreen);
    }
    // loads settings screen
    public void LoadSettings() {
        string MainScreen = "SettingsScreen";
        SceneManager.LoadScene(MainScreen);
    }
    public void LoadQuit() {
        Application.Quit();
    }

    // loads tutorial
    public void LoadTutorial() {
        string MainScreen = "tutorialScreen";
        SceneManager.LoadScene(MainScreen);
    }
    
}
