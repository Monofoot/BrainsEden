using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovementLR : MonoBehaviour
{

    Rigidbody2D rigBod;
    public float thrust = 0.5f;
    public float maxVelocity = 10;
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


    private void Update()
    {
        //If touch input is detected, jump the character
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            //rotate by x degrees
            rigBod.AddForce(jumpPower);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get horizontal and vertical axis
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Clamps the max velocity by taking the rigid body and the float max velocity
        rigBod.velocity = Vector2.ClampMagnitude(rigBod.velocity, maxVelocity);

        //Collision detection, resumes normal movement when the player collides with an object
        if (playerCollScript.stop)
        {
            return;
        }

        rigBod.AddRelativeForce(Vector2.right * thrust);
        Vector2 velocity = rigBod.velocity;

    }
}
