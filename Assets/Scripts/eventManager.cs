using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, 0);

        this.transform.position += movement * Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            
            Destroy(collision.gameObject);
        }
    }
}
