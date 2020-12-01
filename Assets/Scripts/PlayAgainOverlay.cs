using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainOverlay : MonoBehaviour
{
    public GameObject playAgainOverlay;

    public void LoadGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MAIN SCENE");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void ShowOverlay() {
        playAgainOverlay.SetActive(true);
    }
}