// written by tariq scott
/* This test is for Player.cs */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayMode
    {
        [Test]
        public void object_checker()
        {
            // Use the Assert class to test conditions
            SceneManager.LoadScene("MAIN SCENE");
            GameObject temp = GameObject.Find("Player");
            var collectible0 = GameObject.FindGameObjectsWithTag("RockPickup");
            var collectible1 = GameObject.FindGameObjectsWithTag("Gem");
            var collectible2 = GameObject.FindGameObjectsWithTag("Crystal");
            var collectible3 = GameObject.FindGameObjectsWithTag("Coin");

            PlayModeWithEnumeratorPasses();
            Assert.NotNull(collectible0);
            Assert.NotNull(collectible1);
            Assert.NotNull(collectible2);
            Assert.NotNull(collectible3);
        }

        [UnityTest]
        public IEnumerator PlayModeWithEnumeratorPasses()
        {
            Assert.IsTrue(true);
            yield return null;
        }
    }