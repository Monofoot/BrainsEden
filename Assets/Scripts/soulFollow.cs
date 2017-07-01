using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulFollow : MonoBehaviour {

    bool collisionFound = false;
    int soulCount;

    public GameObject holdSlot1;
    public GameObject holdSlot2;
    public GameObject holdSlot3;
    public GameObject playerGameObject;

    playerCollision playerCollideScript;

    private void Start()
    {
        playerCollideScript = playerGameObject.GetComponent<playerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionFound)
        {
            if(soulCount == 1)
            {
                transform.position = holdSlot1.transform.position;
                transform.localScale = holdSlot1.transform.lossyScale;
                transform.gameObject.tag = "SoulPickedUp";
            }
            else if (soulCount == 2)
            {
                transform.position = holdSlot2.transform.position;
                transform.localScale = holdSlot2.transform.lossyScale;
                transform.gameObject.tag = "SoulPickedUp";
            }
            else if (soulCount == 3)
            {
                transform.position = holdSlot3.transform.position;
                transform.localScale = holdSlot3.transform.lossyScale;
                transform.gameObject.tag = "SoulPickedUp";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collisionFound = true;
            playerCollideScript.slotFilled();
            soulCount = playerCollideScript.checkSlots();
        }
    }
}
