/// @author Tariq Scott
///<summary>
/// HealthBar.cs sets the slider health, 
/// maximizes it on start, and allows the 
/// colors to change as the health does.
///</summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Allows us to create a variable to store our slider 

public class HealthBar : MonoBehaviour
{
    public Slider slider; // Reference to slider
    public Gradient gradient; // Allows for the change of colors 
    public Image fill;

    /// Sets our health slider to start at max health 
    /// <param name = "health"> is the arbitrary amount of health </param>
    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        
        fill.color = gradient.Evaluate(1f);
    }

    /// Sets the health on the slider
    /// param "health" is the arbitrary amount of health
   public void SetHealth(int health) {
       slider.value = health;

       fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
