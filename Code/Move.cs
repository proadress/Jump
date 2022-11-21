using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Move : MonoBehaviour
{
    public float xspeed;
    public float[] jumpspeed;
    public TMP_Text scoretext;
    Rigidbody2D myRigidBody;
    BoxCollider2D feet;
    bool isRight, noGround;
    float moveDir;
    int hight;
    public ETCJoystick joystick;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        feet = GetComponent<BoxCollider2D>();
        isRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Word();
    }
    void Word()
    {
        int high = ((int)transform.position.y + 5);
        if (high > hight) hight = high;

        scoretext.text = "HIGHT:" + PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", hight);
    }

    void Run()
    {
        moveDir = joystick.axisX.axisValue;
        //Input.GetAxis("Horizontal");
        
        /*if (Input.GetKey("d"))moveDir = 1;
        else if (Input.GetKey("a"))moveDir = -1;
        else moveDir = 0;*/
        Flip();
        myRigidBody.velocity = new Vector2(moveDir * xspeed, myRigidBody.velocity.y);
    }

    void Jump()
    {
        if (myRigidBody.velocity.y < 0.1f)
        {
            myRigidBody.velocity =
            feet.IsTouchingLayers(LayerMask.GetMask("Stair")) ?
            Vector2.up * jumpspeed[0] :
            feet.IsTouchingLayers(LayerMask.GetMask("Stair1")) ?
            Vector2.up * jumpspeed[1] :
            feet.IsTouchingLayers(LayerMask.GetMask("Stair2")) ?
            Vector2.up * jumpspeed[2] : myRigidBody.velocity;
        }
        if (feet.IsTouchingLayers(LayerMask.GetMask("Stair")))
            noGround = true;
        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (noGround)
            {
                SceneManager.LoadScene(2);
            }
            myRigidBody.velocity = Vector2.up * jumpspeed[0];
        }
        if(myRigidBody.velocity.x<-20)SceneManager.LoadScene(2);
    }

    void Flip()
    {
        bool playrHasXAxisSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playrHasXAxisSpeed)
        {
            if (myRigidBody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRigidBody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
