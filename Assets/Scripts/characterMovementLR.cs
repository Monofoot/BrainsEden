using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovementLR : MonoBehaviour {

    Rigidbody2D rigBod;
    public float thrust = 0.5f;

    // Use this for initialization
    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rigBod.AddRelativeForce(Vector3.right * thrust);


    }
}
