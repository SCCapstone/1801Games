 using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class AchievenmentManager : MonoBehaviour
{
    // A prefab used for creating a new achievement
    public GameObject achievementPerfab;

    // A reference to the scrollrect that controls the achievements in the menu
    public ScrollRect scrollRect;

    // A reference to enable open and close the achievement menu
    public GameObject achievementMenu;

    // A reference to pop out achievement in main screen when the achievement is earned
    public GameObject visualAchievement;

    //create a dictionary to store every achievements
    public Dictionary<string, Achievements> achievements = new Dictionary<string, Achievements>();
    // Start is called before the first frame update
    //initialize
    void Start()
    {
        
        //Creates the general achievments
        CreateAchievement("General","Press W", "Press W to unlock this achievement");
        CreateAchievement("General", "Press A", "Press A to unlock this achievment");
        CreateAchievement("General", "Press S", "Press S to unlock this achievment");
        CreateAchievement("General", "Press D", "Press D to unlock this achievment");

        //achiement menu ususlly is closed
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
        //Checks if its the first time we try to unlock the achievment
        if(achievements[title].EarnAchievement())
        {   
            //Instantiates the visual achievment
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            //akes the visual achievment a child of the EarnCanvas, so that it is visible for the user
            SetAchievenmentInfo("EarnCanvas", achievement, title);
            //Makes the achievment pop out and hide of the screen
            StartCoroutine(HideAchievement(achievement));
        }
    }
    public IEnumerator HideAchievement(GameObject achievement)
    {
        //when a new achievement unlock, it will only remain 3 secounds in the game screen
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    // Creates an achievment
    // <param name="parent">The achievment's parent</param>
    // <param name="title">The title of the achievment</param>
    // <param name="description">The achievment's description</param>
    public void CreateAchievement(string parent, string title, string description)
    {
        //create a achievement object from the pattern already made
        GameObject achievement = (GameObject)Instantiate(achievementPerfab);
        //create a new achievement 
        Achievements newAchievement = new Achievements(title, description, achievement);
        //add this achievement to dictionary
        achievements.Add(title, newAchievement);
        //Makes sure that the achievment contains the correct info
        SetAchievenmentInfo(parent, achievement, title);
    }
    // set an achievment information 
    // <param name="parent">The achievment's parent</param>
    // <param name="title">The title of the achievment</param>
    // <param name="description">The achievment's description</param>
    public void SetAchievenmentInfo(string parent, GameObject achievement,string title)
    {
        //Sets the parent of the achievments
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        //Make sure it has correct size
        achievement.transform.localScale = new Vector3(1, 1, 1);
        //enable to input the achievment title and description
        achievement.transform.GetChild(0).GetComponent<Text>().text = title;
        achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
    }
}
