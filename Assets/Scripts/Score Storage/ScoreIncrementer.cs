// Written by Tariq Scott

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrementer : MonoBehaviour {

  public Text HighScoreText;
  public Text ScoreText;
  float Score;
  int HighScore;

  void Start() {
    // Do NOT uncomment this unless a user wants to delete current high score.
    // PlayerPrefs.DeleteAll();
     Score = 0;
  }

  void Update {
    score += Time.deltaTime * 5;
    HighScore = (int)Score;
    ScoreText.Text = HighScore.ToString();

    if (PlayerPrefs.GetInt("Score") <= HighScore) {
      PlayerPrefs.setInt("Score", HighScore);
    }
  }

  public void HighScore() {
    HighScoreText.Text = PlayerPrefs.GetInt("Score").ToString();
  }
}*/
