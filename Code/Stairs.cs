using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform target;
    public ObjectPool[] pool;
    public Vector2 yrange;
    public Vector2 xrange;
    public int[] sp;
    float y = 0;
    int result = 1;
    void Update()
    {
        if (target.position.y > y - 10)
        {
            int type = 0;
            result = Random.Range(0, sp[0] + sp[1] + sp[2]);
            if (result < sp[0]) type = 0;
            else if (result >= sp[0] && result < sp[0] + sp[1]) type = 1;
            else if (result >= sp[0] + sp[1]) type = 2;
            pool[type].ReUse(new Vector3(Random.Range(xrange[0], xrange[1]), y, 0));
            y += Random.Range(yrange[0], yrange[1]);
        }
    }
}
