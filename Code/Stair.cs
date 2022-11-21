using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    int Short = 4;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("score")>transform.position.y+15)
        {
            GameObject.Find(transform.parent.name).GetComponent<ObjectPool>().Recovery(gameObject);
        }
        if (transform.position.y / 200 < 4)
            Short = (int)(transform.position.y / 200);
        gameObject.transform.localScale = new Vector3(4.5f - Short, 0.3f, 0f);
    }
}
