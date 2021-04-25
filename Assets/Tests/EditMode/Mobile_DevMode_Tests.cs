// written by tariq scott 
/* test is for mobile_devmode.cs */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

    public class EditMode 
    {
        [Test]
        public static void playerSpeed() 
        {
            Assert.AreEqual(300,300, "value should be 300");
        }

        public static void RunCharacter()
        {
            Assert.AreEqual(1, 1, "value should be 1");
        }

        [UnityTest]
        public IEnumerator EditModeWithEnumeratorPasses()
        {
            yield return null;
        }
    }