// Written by Tariq Scott

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB; 
    public Transform circle;
    public Transform outerCircle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*  
        For PC movement.
            Outputs an X and Y value between -1 and 1.
            A value of zero indicates the joystick is not being touched at all. 
        */
        moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        /*
            For mobile movement.
        */
        if (Input.GetMouseButtonDown(0)) {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                     Input.mousePosition.y,
                     Camera.main.transform.position.z));
            circle.transform.position = pointA * 1;
            outerCircle.transform.position = pointA * 1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetMouseButtonDown(0)) {
            touchStart =  true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                     Input.mousePosition.y,
                     Camera.main.transform.position.z)); 
        } else {
            touchStart = false;
        }
    }

    private void FixedUpdate() {
        if(touchStart) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * +1); // Reverses values so that they point in the correct direction
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        } else {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    void moveCharacter(Vector2 direction) {
        player.Translate(direction * speed *Time.deltaTime); // Tells this function where to move and how fast 
    }
}
