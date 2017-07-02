using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenCollision : MonoBehaviour {

    private float delayDuration = 3.0f;
    private bool inTrigger = false;
    private float heavenPush = 0;
    

    GiveandTake gntScript;

    private void Start()
    {
        GameObject giveAndTakeObject = GameObject.FindGameObjectWithTag("GiveAndTake");
        gntScript = giveAndTakeObject.GetComponent<GiveandTake>();
    }

    IEnumerator delay()
    {
        inTrigger = true;
        yield return new WaitForSeconds(delayDuration);
        if (inTrigger)
        {
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(delay());
            collision.gameObject.GetComponent<playerCollision>().soulCount = 0;

            GameObject[] souls = GameObject.FindGameObjectsWithTag("SoulPickedUp");

            heavenPush = souls.Length;

            for(int i = 0; i < souls.Length; i++)
            {
                souls[i].SetActive(false);
            }

            gntScript.addScore(heavenPush);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
