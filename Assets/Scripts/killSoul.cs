using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSoul : MonoBehaviour {

    public bool seen = false;

    private void OnBecameVisible()
    {
        seen = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
