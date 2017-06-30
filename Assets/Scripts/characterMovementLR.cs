using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovementLR : MonoBehaviour {

    Rigidbody2D rigBod;
    public float thrust = 0.5f;
    private GameObject playerCollider;
    private playerCollision playerCollScript;

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
        if (playerCollScript.stop)
        {
            return;
        }

        rigBod.AddRelativeForce(Vector3.right * thrust);
    }
}
