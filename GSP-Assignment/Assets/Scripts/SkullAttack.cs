using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAttack : MonoBehaviour
{
    //Player Attributes
    public Transform playerModel;
    public GameObject explosionParticles;
    public Enemy Skull;

    //Enemy Health Bar and other misc
    public HealthBarScript healthbar;
    public AudioClip explosionSound;
    public EnemyController enemyScript;
    

    void Start()
    {
        //explosionSound = GetComponent<AudioSource>();
        //healthbar = GetComponent<HealthBarScript>();

  
        EnemyController enemyScript = GetComponent<EnemyController>();
        playerModel = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if(playerModel != null && enemyScript.lookRadius <= enemyScript.distance )
        {
            transform.LookAt(playerModel);
        }

 

    }

    void Update()
    {
        if (Skull.currentHealth <= 0)
        {
            Die();
        }
    }




    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform == playerModel)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);

        }


    }

    void Die()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }
}

