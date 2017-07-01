using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOffScreen : MonoBehaviour {

    private bool hasAppeared;
    private SpriteRenderer rnd;

    // Use this for initialization
    void Start() {
        rnd = GetComponent<SpriteRenderer>();
        hasAppeared = false;
        //Check if element has appeared in the camera 
    }

    private void FixedUpdate()
    {
        if (rnd.isVisible)
        {
            hasAppeared = true;
        }
    }

    // Update is called once per frame
    void OnBecameInvisible () {

        //if element has been on screen and is no longer visible on screen
        if (hasAppeared)
        {
            //Destoy the attached gameobject
                Destroy(this.gameObject);
        }
	}
}
