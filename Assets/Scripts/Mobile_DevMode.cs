// written by tariq scott

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile_DevMode : MonoBehaviour
{

    public float moveSpeed = 300f;
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        // loop over every touch found
        while(i < Input.touchCount) {
            if(Input.GetTouch(i).position.x > ScreenWidth / 2) {
                // move right
                RunCharacter(1.0f);
            }

            if(Input.GetTouch(i).position.x < ScreenWidth / 2) {
                // move left
                RunCharacter(1.0f);
            }

            if (Input.GetTouch(i).position.y > ScreenWidth / 2) {
                // move up
                RunCharacter(1.0f);
            }

            if (Input.GetTouch(i).position.y > ScreenWidth / 2) {
                // move down
                RunCharacter(1.0f);
            }
            ++i;
        }
    }

    void FixedUpdate() {
        #if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        #endif
    }

    private void RunCharacter(float horizontalInput) {
        // moves player
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));

    }
}
