using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        //When player takes damage remove that amount damage to player's current HP
        currentHealth -= damage;

        //Update UI health bar
        healthbar.SetHealth(currentHealth);
    }
}
