using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public HealthBarScript healthbar;
   

    // Start is called before the first frame update
    void Start()
    {
        //Set the player health to the max health.
        currentHealth = maxHealth;

        //Set the UI health bar to the player's max health.
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
        }

    }

    void takeDamage(int damage)
    {
        //When player takes damage remove that amount damage to player's current HP
        currentHealth -= damage;

        //Update UI health bar
        healthbar.SetHealth(currentHealth);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            takeDamage(5);
        }

        if (col.gameObject.tag == "bullet")
        {
            takeDamage(5);
        }
    }
}
