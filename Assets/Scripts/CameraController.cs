using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform lookAt = null;
    public float smoothSpeed = 5f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        //Set the cameras offset by the cameras world position away from the target
        offset = this.transform.position - lookAt.transform.position;    
    }

    private void FixedUpdate()
    {
        //Vector3 cameraHell = new Vector3(transform.position.x, transform.position.y - 0.01f);

        //transform.position = cameraHell;
    } 

    private void LateUpdate()
    {
        //Lookat = new transform to lerp towards 
        Vector3 targetPos = lookAt.transform.position + offset; 
        //smooth follow towards new target position
        transform.position = Vector3.Lerp(transform.position ,targetPos, smoothSpeed * Time.deltaTime);
    }

}

