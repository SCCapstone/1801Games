using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
namespace Tests
{
    public class PlayMode
    {
        // A Test behaves as an ordinary method
        [Test]
        public void GameObjects_Are_Generated()
        {
            // Use the Assert class to test conditions
            
            SceneManager.LoadScene("MAIN SCENE");
            GameObject player = GameObject.Find("Player");
            var playerFound = GameObject.FindGameObjectsWithTag("Player");
            var enemyFound = GameObject.FindGameObjectsWithTag("Enemy");
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            PlayModeWithEnumeratorPasses();
            Assert.NotNull(playerFound);
            Assert.NotNull(enemyFound);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.


        [UnityTest]
        public IEnumerator PlayModeWithEnumeratorPasses()
        {
            Assert.IsTrue(true);
            yield return null;
        }
    }
}
