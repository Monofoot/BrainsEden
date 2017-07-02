using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveandTake : MonoBehaviour {

    [Range(-100,100)]
    public float giveAndTakeMeter = 0f;
    public float hellRise = 0.08f;



    IEnumerator increaseAfterMinute()
    {
        yield return new WaitForSeconds(60);
        hellRise = 0.12f;
    }

    IEnumerator increaseAfter2Minutes()
    {
        yield return new WaitForSeconds(120);
        hellRise = 0.18f;
    }

    private void Awake()
    {
        StartCoroutine(increaseAfterMinute());
        StartCoroutine(increaseAfter2Minutes());
    }

    private void Update()
    {
        if(giveAndTakeMeter > -100)
        {
            giveAndTakeMeter -= hellRise;
        }
        else
        {
            //call end game
        }
    }

    public void addScore(float scoreToAdd)
    {
        Debug.Log("here");
        Debug.Log(scoreToAdd);
        giveAndTakeMeter += scoreToAdd;
        Debug.Log(giveAndTakeMeter);
    }

    public float getMeter()
    {
        return giveAndTakeMeter;
    }
}
