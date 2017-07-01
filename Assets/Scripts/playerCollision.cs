using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public SpriteRenderer rend;
    public bool stop = false;
    public float PlayerDelayDuration = 0.2f;
    public int timerSeconds = 6;
    public float flashSpeed = 5f;
    private bool damaged = false;

    playerHealth pHealth;

    private void Awake()
    {
        pHealth = GetComponent<playerHealth>();
    }

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = true;
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
        if (collision.collider.tag == "Obstacle")
        {
            damaged = true;
            Destroy(collision.gameObject);
            pHealth.TakeDamage(10);
            StartCoroutine(delayOnCollision());
        }
    }
}
