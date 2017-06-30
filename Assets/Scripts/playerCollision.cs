using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public Rigidbody2D rb;
    public bool stop = false;
    public float PlayerDelayDuration = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator delayOnCollision()
    {
        stop = true;
        yield return new WaitForSeconds(PlayerDelayDuration);
        stop = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            StartCoroutine(delayOnCollision());
        }
    }
}
