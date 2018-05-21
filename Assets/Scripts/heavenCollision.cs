using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenCollision : MonoBehaviour {

    private float delayDuration = 3.0f;
    private bool inTrigger = false;
    private float heavenPush = 0;
    public float flashSpeed = 5f;

    GiveandTake gntScript;

    private void Start()
    {
        GameObject giveAndTakeObject = GameObject.FindGameObjectWithTag("GiveAndTake");
        gntScript = giveAndTakeObject.GetComponent<GiveandTake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<playerCollision>().soulCount > 0)
            {
                collision.gameObject.GetComponent<playerCollision>().give = true;
                collision.gameObject.GetComponent<playerCollision>().soulCount = 0;
            }
            
            

            GameObject[] souls = GameObject.FindGameObjectsWithTag("SoulPickedUp");

            heavenPush = souls.Length;

            if(souls.Length > 0)
            {
                
            }

            for(int i = 0; i < souls.Length; i++)
            {
                souls[i].SetActive(false);
            }

            gntScript.addScore(heavenPush);
        }
    }
}
