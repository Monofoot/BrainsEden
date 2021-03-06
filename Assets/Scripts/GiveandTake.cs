﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GiveandTake : MonoBehaviour {

    [Range(-100,100)]
    public float giveAndTakeMeter = 0f;
    public float hellRise = 0.1f;
    private float totalSouls = 0;


    IEnumerator increaseAfterMinute()
    {
        yield return new WaitForSeconds(60);
        hellRise = 0.14f;
    }

    IEnumerator increaseAfter2Minutes()
    {
        yield return new WaitForSeconds(120);
        hellRise = 0.2f;
    }

    private void Awake()
    {
        StartCoroutine(increaseAfterMinute());
        StartCoroutine(increaseAfter2Minutes());
        InfoManager.soulsSaved = 0;
    }

    private void Update()
    {
        if(giveAndTakeMeter > -100)
        {
            //giveAndTakeMeter -= hellRise;
        }
        else
        {
            //SceneManager.LoadScene(2);
        }
    }

    public void addScore(float scoreToAdd)
    {
        InfoManager.soulsSaved += scoreToAdd;

        if(giveAndTakeMeter < 100 && scoreToAdd <= 3 && scoreToAdd > 0)
        {
            scoreToAdd /= 10;

            GameObject[] hell = GameObject.FindGameObjectsWithTag("Hell");

            for (int i = 0; i < hell.Length; i++)
            {
                hell[i].transform.position = new Vector2(hell[i].transform.position.x, hell[i].transform.position.y - scoreToAdd);
            }
        }
        
    }

    public float getMeter()
    {
        return giveAndTakeMeter;
    }

    public float getSoulsSaved()
    {
        return totalSouls;
    }
}
