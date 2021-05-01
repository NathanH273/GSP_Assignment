
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //health
    public int currentHealth;
    public int maxHealth = 100;

    public HealthBarScript healthbar;

    //i frames
    private bool isInvincible = false;
    public float invincibilityTime = 1.5f;
    public float invincibilityDeltaTime = 0.15f;

    //playermodel
    public GameObject model;


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
      
    }

    public void takeDamage(int damage)
    {
        if (isInvincible) return;

        //When player takes damage remove that amount damage to player's current HP
        currentHealth -= damage;

        //Update UI health bar
        healthbar.SetHealth(currentHealth);

        StartCoroutine(temporarilyInvincible());
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            takeDamage(5);
        }

        if (col.gameObject.tag == "bullet")
        {
            takeDamage(5);
        }

        if (col.gameObject.tag == "Enemy Skull Boss")
        {
            takeDamage(10);
        }
    }

    private IEnumerator temporarilyInvincible()
    {
        isInvincible = true;
        //Debug.Log("player invisible");

        for (float i = 0; i < invincibilityTime; i += invincibilityDeltaTime)
        {
            
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        isInvincible = false;
        //Debug.Log("player not invisible");
    }

 
}
