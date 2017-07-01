using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public BackgroundGenerator bgGen;
    public RemoveOffScreen remov;

    private int level = 3;
 
    // Use this for initialization

    void Awake ()
    {
        bgGen = GetComponent<BackgroundGenerator>();
        remov = GetComponentInChildren<RemoveOffScreen>();
        InitGame();
	}
	
    void InitGame()
    {
        bgGen.SetupScene(level);
    }

}
