﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public SpriteRenderer rend;
    public bool stop = false;
    public float PlayerDelayDuration = 0.2f;
    public float flashSpeed = 5f;
    private bool damaged = false;
    bool damn = false;
    private int soulCount = 0;

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
        if (collision.collider.tag == "Obstacle")
        {
            damaged = true;
            Destroy(collision.gameObject);
            StartCoroutine(delayOnCollision());
        }
    }

    public int checkSlots()
    {
        return soulCount;
    }

    public void slotFilled()
    {
        soulCount++;
    }
}
