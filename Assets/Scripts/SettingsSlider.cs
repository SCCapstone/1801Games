// written by Tariq Scott
// SettingsSlider.cs allows you to slide the sounds in the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsSlider : MonoBehaviour
{
   public AudioMixer audioMixer;

   public void setMusic(float music) {
       audioMixer.SetFloat("music", Mathf.Log10(music) * 20);
   }

//    public void setSound(float sound) {
//        audioMixer.SetFloat("sound", sound);
//    }


}
