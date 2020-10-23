using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WRITTEN BY BRADLEY WILLIAMSON
public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.instance.ChangeScore(coinValue);
        }
    }
}
