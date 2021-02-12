using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DaVonte Blakely
public class EnemyMove2d : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxJumpHeight = 4f; 
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Random.Range(1,100) < 5)
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, maxJumpHeight), ForceMode2D.Impulse);
        if(timer > 3)
        {
            timer = 0;
        }
        // Enemy movemen
        Vector3 movementL = Vector3.left;
        Vector3 movementR = Vector3.right;
        if(timer < 1.5)
        {
            transform.position += movementL * Time.deltaTime * moveSpeed;
        }
        else if(timer > 1.5)
        {
             transform.position += movementR * Time.deltaTime * moveSpeed;
        }
        
    }

        public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Add in Sound 
        }
        if(other.gameObject.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
