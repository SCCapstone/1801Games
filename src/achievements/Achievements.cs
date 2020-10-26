using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements
{
    // The name of the achievments
    private string name;
    
    //The discription of the achievement
    private string description;

    // Indicates if the achievment is unlocked
    private bool unlocked;

    // A reference to the achievment objects
    private GameObject achievementRef;

    // The achievment's constructor
    public Achievements(string name, string description, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.achievementRef = achievementRef;
    }

    // Earns the achievments
    // </summary>
    // <returns>True if the achievment was earned</returns>
    public bool EarnAchievement()
    {
        if(!unlocked)
        {
            unlocked = true;
            return true;
        }
        return false;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
        public bool Unlocked
    {
        get { return unlocked; }
        set { unlocked = value; }
    }
}
