using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    private void Awake()
    {
        currentHealth = startHealth;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            //end game
        }
    }
}
