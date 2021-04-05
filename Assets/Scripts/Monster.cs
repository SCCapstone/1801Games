//by Yiqian Sun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    public GameObject bulletParent;

    float fireRate;
    float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.7f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire ();
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate (bullet,bulletParent.transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
