using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 targetPos = target.position + offset - new Vector3(0, 0, 6);
        Vector3 interpolate = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = interpolate;
    }
}
