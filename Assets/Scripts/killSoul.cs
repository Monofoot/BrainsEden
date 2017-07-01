using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSoul : MonoBehaviour {

    public PickupGenerator PG;
    public bool seen = false;

    private void Start()
    {
        PG = GetComponentInParent<PickupGenerator>();
    }

    private void OnBecameVisible()
    {
        seen = true;
    }

    private void OnBecameInvisible()
    {
        
        Destroy(this.gameObject);
    }
}
