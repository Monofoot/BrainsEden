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
    public bool give = false;
    public int soulCount = 0;

    public GameObject soul1;
    public GameObject soul2;
    public GameObject soul3;

    public AudioSource pickup;
    public AudioSource deathAudio;
    
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
        else if(!damaged)
        {
            rend.color = Color.Lerp(rend.color, Color.white, flashSpeed * Time.deltaTime);
        }
        damaged = false;

        if (give)
        {
            rend.color = Color.green;
        }
        else if (!give)
        {
            rend.color = Color.Lerp(rend.color, Color.white, flashSpeed * Time.deltaTime);
        }
        give = false;

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
        if (collision.collider.tag == "Obstacle" || collision.collider.tag == "Hell")
        {
            damaged = true;

            if(soulCount > 0)
            {
                GameObject[] souls = GameObject.FindGameObjectsWithTag("SoulPickedUp");

                for (int i = 0; i < souls.Length; i++)
                {
                    souls[i].SetActive(false);
                }

                soulCount = 0;
            }
            else
            {
                deathAudio.Play();
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
            pickup.Play();
            soulCount++;

            Destroy(collision.gameObject);
        }
    }
}
