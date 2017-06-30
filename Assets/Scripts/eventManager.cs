using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour {

    private GameObject playerCollider;
    private playerCollision playerCollScript;

    private void Start()
    {
        playerCollider = GameObject.Find("Player");
        playerCollScript = playerCollider.GetComponent<playerCollision>();
    }

    // Update is called once per frame
    void Update () {

        //if(playerCollScript.stop)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, 0);

        this.transform.position += movement * Time.deltaTime;
	}
}
