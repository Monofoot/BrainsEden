using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform lookAt = null;
    public float smoothSpeed = 20f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = this.transform.position - lookAt.transform.position;    
    }

    private void LateUpdate()
    {
        Vector3 targetPos = lookAt.transform.position + offset; 
        this.transform.position = Vector3.Lerp(this.transform.position ,targetPos, smoothSpeed * Time.deltaTime);
    }

}

