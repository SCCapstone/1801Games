using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPEEDGEM : MonoBehaviour
{

    public int speedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Move2d.MoveSpeed();
        }
    }
}
