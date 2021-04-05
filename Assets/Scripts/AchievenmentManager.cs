//By Yiqian Sun
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class AchievenmentManager : MonoBehaviour
{
    public GameObject achievementPerfab;

    public ScrollRect scrollRect;

    public GameObject achievementMenu;

    public GameObject visualAchievement;

    //create a dictionary to store achievements
    public Dictionary<string, Achievements> achievements = new Dictionary<string, Achievements>();
    // Start is called before the first frame update
    void Start()
    {

        CreateAchievement("General","Press W", "Press W to unlock this achievement");
        CreateAchievement("General", "Press A", "Press A to unlock this achievment");
        CreateAchievement("General", "Press S", "Press S to unlock this achievment");
        CreateAchievement("General", "Press D", "Press D to unlock this achievment");

        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Press U to open the achievement screen
        if(Input.GetKeyDown(KeyCode.U))
        {
            achievementMenu.SetActive(!achievementMenu.activeSelf);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Press W");
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            EarnAchievement("Press A");
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            EarnAchievement("Press S");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            EarnAchievement("Press D");
        }
    }
    public void EarnAchievement(string title)
    {
        if(achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievenmentInfo("EarnCanvas", achievement, title);
            //Makes the achievment fad in and out of the screen
            StartCoroutine(HideAchievement(achievement));
        }
    }
    public IEnumerator HideAchievement(GameObject achievement)
    {
        //when a new achievement unlock, it will only remain 3 secounds in the game screen
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }
    public void CreateAchievement(string parent, string title, string description)
    {
        //create a achievement from the pattern already made
        GameObject achievement = (GameObject)Instantiate(achievementPerfab);
        Achievements newAchievement = new Achievements(title, description, achievement);
        achievements.Add(title, newAchievement);
        SetAchievenmentInfo(parent, achievement, title);
    }
    public void SetAchievenmentInfo(string parent, GameObject achievement,string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        //enable to input the achievment title and description
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
    }
}
