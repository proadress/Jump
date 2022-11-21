using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    void FixedUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                targetPos[0] = 0;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);

                //transform.position = targetPos;
            }
        }
    }
}
