// Written By Bradley Williamson
// Edited By Tariq Scott 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // if escape is pressed and game is paused resume else pause it
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
        
    }
    // pause method, activates the menu and slows time
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    // opposite of pause
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    //loads Start Menu
    public void LoadMenu() {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitMenu() {
        Application.Quit();
    }

    // Loads Sound Menu
    public void SoundMenu() {
        SceneManager.LoadScene("music");
    }

    // Loads Credits Menu
    public void CreditsMenu() {
        SceneManager.LoadScene("CreditsMenu");
    }

    // Loads Settings Menu
    public void SettingsMenu() {
        SceneManager.LoadScene("SettingsScreen");
    }

    //Loads First Tutorial Screen
    public void TutorialScreenOne() {
        SceneManager.LoadScene("TutorialScreenOne");
        }

    // Loads Seconds Tutorial Screen
    public void TutorialScreenTwo() {
        SceneManager.LoadScene("TutorialScreenTwo");
     }
}
