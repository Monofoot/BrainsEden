using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerCollision : MonoBehaviour {

    public SpriteRenderer rend;
    public bool stop = false;
    bool collisionFound = false;
    public float PlayerDelayDuration = 0.2f;
    public float flashSpeed = 5f;
    private bool damaged = false;
    public int soulCount = 0;

    public GameObject soul1;
    public GameObject soul2;
    public GameObject soul3;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (collisionFound)
        {
            if (soulCount == 1)
            {
                soul1.SetActive(true);
            }
            else if (soulCount == 2)
            {
                soul2.SetActive(true);
            }
            else if (soulCount == 3)
            {
                soul3.SetActive(true);
            }
        }

        if (damaged)
        {
            rend.color = Color.red;
        }
        else
        {
            rend.color = Color.Lerp(rend.color, Color.white, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        InfoManager.checkIfSoulsPresent = soulCount;
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

            if(soulCount > 0)
            {
                GameObject[] souls = GameObject.FindGameObjectsWithTag("SoulPickedUp");

                foreach(GameObject soul in souls)
                {
                    Destroy(soul);
                }
            }
            else
            {
                SceneManager.LoadScene(2);
            }
            
            StartCoroutine(delayOnCollision());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Soul")
        {
            collisionFound = true;
            slotFilled();

            Destroy(collision.gameObject);
        }
    }

    public void slotFilled()
    {
        soulCount++;
    }
}
