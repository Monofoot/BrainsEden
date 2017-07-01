using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public SpriteRenderer rend;
    public bool stop = false;
    public float PlayerDelayDuration = 0.2f;
    public float flashSpeed = 5f;
    private bool damaged = false;
    private Vector3 holdPosition;
    private float holdX = -0.15f;

    soulFollow soulPickup;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        soulPickup = GetComponent<soulFollow>();
    }

    private void Update()
    {
        if (damaged)
        {

            rend.color = Color.white;
        }
        else
        {
            rend.color = Color.Lerp(rend.color, Color.red, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    IEnumerator delayOnCollision()
    {
        stop = true;
        yield return new WaitForSeconds(PlayerDelayDuration);
        stop = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Soul")
        {
            GameObject holdSlot = new GameObject("holdSlot");
            transform.parent = holdSlot.transform;
            holdPosition = new Vector3(holdX, transform.position.y, transform.position.z);
            holdSlot.transform.Translate(holdPosition);

            soulPickup.collisionOccur(true, holdSlot);
        }
        else if (collision.collider.tag == "Obstacle")
        {
            damaged = true;
            Destroy(collision.gameObject);
            StartCoroutine(delayOnCollision());
        }
    }
}
