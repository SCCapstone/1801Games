//By Yiqian Sun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements
{
    private string name;
    
    private string description;

    private bool unlocked;

    private GameObject achievementRef;

    public Achievements(string name, string description, GameObject achievementRef)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.achievementRef = achievementRef;
    }

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
