using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour {

    public static float soulsSaved;
    public static InfoManager manager;

    GiveandTake gntScript;

    private void Awake()
    {
        if(manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager != null)
        {
            Destroy(gameObject);
        }
    }
}
