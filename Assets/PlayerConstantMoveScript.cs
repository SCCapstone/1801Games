using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstantMove : MonoBehaviour
{

    GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameController.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gameManager.moveVector * gameManager.moveSpeed * Time.deltaTime);
    }
}
