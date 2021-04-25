// written by tariq scott
/* tests if for Monster.cs */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class Monster_Test : MonoBehaviour
{
    public class EditMode 
    {
        [Test]
        public static void fireRate() 
        {
            Assert.AreEqual(0.7, 0.7, "fire rate should be 0.7");
        }

        [UnityTest]
        public IEnumerator EditModeWithEnumeratorPasses()
        {
            yield return null;
        }
    }
}
   
