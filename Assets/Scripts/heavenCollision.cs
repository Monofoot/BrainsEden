using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavenCollision : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SoulPickedUp")
        {
            Destroy(collision);
        }
    }
}
