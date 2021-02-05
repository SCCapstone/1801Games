using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//using UnityEngine.Assertions;

// Written By BW

namespace Tests
{
    public class TestSuite
    {
        //private GameAssembly game;
        [SetUp]
        public void Setup()
        {
            // Spawn Game 
           GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Scenes/PlayerTakesDamage"));
           //game = gameGameObject.GetComponent<Game>();
        }

        [TearDown]
        public void TearDown()
        {
            //object.Destroy(gameGameObject);
        }
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator PlayerTakesDMG()
        {

            // Spawn Player
            GameObject Player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Free Pixel Space Platform Pack/Astronaut/AstroStay"));
           
            // Spawn Spike
            GameObject Spike = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Free Pixel Space Platform Pack/Spikes/Spike_03"));
            


            //Intial Player Value, since hes floating and were going to wait for .1 second his cordinates will be different, which would mean he died. 
            float initialYPos = Player.transform.position.y;

            yield return new WaitForSeconds(0.1f);
            float secondYPos = Player.transform.position.y;
           
          
            Assert.AreNotEqual(secondYPos, initialYPos);
            
         }
    }
}
