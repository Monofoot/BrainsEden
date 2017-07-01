using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenCollision : MonoBehaviour {

    private float delayDuration = 2.0f;
    private bool inTrigger = false;

    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SoulPickedUp")
        {
            inTrigger = true;

            StartCoroutine(delay());

            if(inTrigger)
            {
                Destroy(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SoulPickedUp")
        {
            inTrigger = false;
        }
    }
}
