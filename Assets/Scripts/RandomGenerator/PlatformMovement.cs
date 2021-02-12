using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DaVonte Blakely
public class PlatformMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        VerticalMovement();

    }

    public void HorizontalMovement()
    {

        if(timer > 1)
        {
            timer = 0;
        }
        // Enemy movement
        Vector3 movementL = Vector3.left;
        Vector3 movementR = Vector3.right;
        if(timer < .5)
        {
            transform.position += movementL * Time.deltaTime * moveSpeed;
        }
        else if(timer > .5)
        {
             transform.position += movementR * Time.deltaTime * moveSpeed;
        }
    }

    public void VerticalMovement()
    {
        if(timer > 1.5)
        {
           timer = 0;
        }
        // Enemy movement
        Vector3 movementU = Vector3.up;
        Vector3 movementD = Vector3.down;
        if(timer < .75)
        {
            transform.position += movementU * Time.deltaTime * moveSpeed;
        }
        else if(timer > .75)
        {
             transform.position += movementD * Time.deltaTime * moveSpeed;
        }
    }

}
