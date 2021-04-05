using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 interpolate = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = targetPos;//interpolate;
    }
}
