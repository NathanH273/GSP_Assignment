using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAttack : MonoBehaviour
{
    //Player Attributes
    public Transform playerModel;
    public GameObject explosionParticles;

    //Enemy Skull Attributes
    private int currentHealth;
    public int maxHealth = 50;

    //Enemy Health Bar and other misc
    public HealthBarScript healthbar;
    public AudioClip explosionSound;
    public EnemyController enemyScript;
    

    void Start()
    {
        //explosionSound = GetComponent<AudioSource>();
        //healthbar = GetComponent<HealthBarScript>();

        //Set the enemy health to the max health.
        currentHealth = maxHealth;

        //Set the UI health bar to the enemy's max health.
        healthbar.SetMaxHealth(maxHealth);

        EnemyController enemyScript = GetComponent<EnemyController>();
        playerModel = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(playerModel != null && enemyScript.lookRadius <= enemyScript.distance )
        {
            transform.LookAt(playerModel);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    void takeDamage(int damage)
    {
        //When player takes damage remove that amount damage to player's current HP
        currentHealth -= damage;

        //Update UI health bar
        healthbar.SetHealth(currentHealth);
    }



    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform == playerModel)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("skull suicide");

        }

        if (collision.gameObject.tag == "Player")
        {
            takeDamage(5);
        }

        if (collision.gameObject.tag == "bullet")
        {
            takeDamage(5);
        }



    }
}

