using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenCollision : MonoBehaviour {

    private float delayDuration = 3.0f;
    private bool inTrigger = false;

    IEnumerator delay()
    {
        inTrigger = true;
        yield return new WaitForSeconds(delayDuration);
        if (inTrigger)
        {
            GameObject[] souls = GameObject.FindGameObjectsWithTag("SoulPickedUp");

            foreach (GameObject soul in souls)
            {
                Destroy(soul);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(delay());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
