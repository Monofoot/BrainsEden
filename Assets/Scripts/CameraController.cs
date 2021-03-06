﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GiveandTake giveTake = null;
    public Transform lookAt = null;
    public float smoothSpeed = 5f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //Set the cameras offset by the cameras world position away from the target
        offset = this.transform.position - lookAt.transform.position;
        giveTake = GetComponentInParent<GiveandTake>();  
    }

    private void LateUpdate()
    {
        //Lookat = new transform to lerp towards 
        Vector3 targetPos = new Vector3(lookAt.transform.position.x, giveTake.getMeter() * Time.deltaTime, this.transform.position.z);
        //smooth follow towards new target position
        transform.position = Vector3.Lerp(this.transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }

}

