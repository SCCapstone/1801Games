using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditModeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void All_Highscores_Are_Stored_Properly()
        {
           Assert.AreEqual(true,PlayerPrefs.HasKey("HighScore1"));
           Assert.AreEqual(true,PlayerPrefs.HasKey("HighScore2"));
           Assert.AreEqual(true,PlayerPrefs.HasKey("HighScore3"));
           Assert.AreEqual(true,PlayerPrefs.HasKey("HighScore4"));
           Assert.AreEqual(true,PlayerPrefs.HasKey("HighScore5"));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EditModeTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
