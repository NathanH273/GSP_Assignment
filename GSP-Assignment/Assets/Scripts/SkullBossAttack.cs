using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBossAttack : MonoBehaviour
{
    //Player Attributes
    public Transform playerModel;
    public GameObject explosionParticles;
    public Enemy Skull;

    //Enemy Health Bar and other misc
    public HealthBarScript healthbar;
    public AudioClip explosionSound;
    public EnemyController enemyScript;
    public GameObject enemySpawn;
    
    void Start()
    {
        //explosionSound = GetComponent<AudioSource>();
        //healthbar = GetComponent<HealthBarScript>();


        EnemyController enemyScript = GetComponent<EnemyController>();
        playerModel = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if (playerModel != null && enemyScript.lookRadius <= enemyScript.distance)
        {
            transform.LookAt(playerModel);
        }



    }

    void Update()
    {
        if (Skull.currentHealth <= 0)
        {
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Die();
        }
    }




    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform == playerModel)
        {
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Instantiate(enemySpawn, transform.position, transform.rotation);
            Instantiate(enemySpawn, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);

        }


    }

    void Die()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(gameObject);
    }
}

