using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        if (target != null)
        {
            if (target.position.y>0)
            {
                if (transform.position.y != target.position.y - 5.5f)
                {
                    transform.position = new Vector3(0, target.position.y - 5.5f, 0);
                }
            }
        }
    }
}
