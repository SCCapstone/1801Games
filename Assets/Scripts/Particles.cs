// Written by Tariq Scott 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;

    public void Update() {
        /*
        if(Input.GetKeyDown(KeyCode.Space)) {
            Collect();
        }
        if(Input.GetTouch(0).phase==0)
        {
            Collect();
        }
        */
    }

    public void Collect() {
        collectParticle.Play();
    }
}
