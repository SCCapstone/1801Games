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
        public void PlayModeSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.


        [UnityTest]
        public IEnumerator PlayModeWithEnumeratorPasses()
        {

            SceneManager.LoadScene("MAIN SCENE");
            GameObject player = GameObject.Find("Player");
            
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(3f);
            Assert.NotNull(player);
            yield return null;
        }
    }
}
