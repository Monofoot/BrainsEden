using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovementLR : MonoBehaviour {

    Rigidbody2D rigBod;
    public float thrust = 0.5f;
    private GameObject playerCollider;
    private playerCollision playerCollScript;
    public Vector2 jumpPower = new Vector2(0, 300);

    // Use this for initialization
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        playerCollider = GameObject.Find("Player");
        playerCollScript = playerCollider.GetComponent<playerCollision>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {




        //Collision detection, resumes normal movement when the player collides with an object
        if (playerCollScript.stop)
        {
            return;
        }


        //If touch input is detected, jump the character
        if (Input.GetMouseButton(0) || Input.GetKeyDown("space"))
        {
            rigBod.velocity = Vector2.zero;
            rigBod.AddForce(jumpPower);
        }
        else //Else continue on course to the right with momentum of thrust
        {
            rigBod.AddRelativeForce(Vector3.right * thrust);

        }
    }
}
