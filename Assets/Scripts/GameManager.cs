using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public BackgroundGenerator bgGen;

    private int level = 3;
    // Use this for initialization

    void Awake ()
    {
        bgGen = GetComponent<BackgroundGenerator>();
        InitGame();
	}
	
    void InitGame()
    {
        bgGen.SetupScene(level);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
