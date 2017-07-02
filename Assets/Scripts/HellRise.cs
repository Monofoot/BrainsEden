using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellRise : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        GameObject[] hell = GameObject.FindGameObjectsWithTag("Hell");

        
        for (int i = 0; i < hell.Length; i++)
        {
            hell[i].transform.position = new Vector2(hell[i].transform.position.x, hell[i].transform.position.y + 0.18f * Time.deltaTime);
        }
    }
}
