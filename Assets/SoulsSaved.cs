using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoulsSaved : MonoBehaviour {

    public Text Souls_Saved;
    private float score;

    private void Start()
    {
        score = InfoManager.soulsSaved;

        Souls_Saved.text = "You Saved " + score + " Souls";
    }
}
