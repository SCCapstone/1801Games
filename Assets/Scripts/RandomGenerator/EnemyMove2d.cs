using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DaVonte Blakely
public class EnemyMove2d : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpHeight = 2f;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(1,100) < 5)
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);

        if(count > 1200)
        {
            count = 0;
        }
        // Enemy movemen
        Vector3 movementL = Vector3.left;
        Vector3 movementR = Vector3.right;
        if(count < 600)
        {
            transform.position += movementL * Time.deltaTime * moveSpeed;
        }
        else if(count > 600)
        {
             transform.position += movementR * Time.deltaTime * moveSpeed;
        }
        count++;
        
    }

        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Add in Sound 
        }
    }
}
