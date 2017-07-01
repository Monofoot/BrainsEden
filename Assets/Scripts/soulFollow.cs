using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulFollow : MonoBehaviour {

    public bool collisionFound = false;
    private GameObject holdSlot;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (collisionFound)
        {
            transform.position = holdSlot.transform.position;
            transform.localScale = holdSlot.transform.localScale;
        }
    }

    public void collisionOccur(bool detect, GameObject slot)
    {
        collisionFound = detect;
        holdSlot = slot;
    }
}
