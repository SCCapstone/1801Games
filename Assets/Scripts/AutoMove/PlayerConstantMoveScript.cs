// //written by Tariq Scott

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerConstantMoveScript : MonoBehaviour
// {

//     GameManagerScript gameManager;

//     void Start()
//     {
//         GameObject gameController = GameObject.FindGameObjectWithTag("Game Controller");
//         gameManager = gameController.GetComponent<GameManagerScript>();

//     }

//     void Update()
//     {
//         transform.Translate(gameManager.moveVector * gameManager.moveSpeed * Time.deltaTime);
//     }
// }
