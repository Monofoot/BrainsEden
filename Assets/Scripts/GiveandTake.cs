using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveandTake : MonoBehaviour {

    [Range(-100,100)]
    public float giveAndTakeMeter = 0f;

    public void addScore(float scoreToAdd)
    {
        giveAndTakeMeter += scoreToAdd;
    }

    public float getMeter()
    {
        return giveAndTakeMeter;
    }
}
