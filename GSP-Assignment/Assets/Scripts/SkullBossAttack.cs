using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public NavMeshAgent boss;

    //Attacks
    private bool spawned = false;

    //timer
    public float timer;
    public float seconds;

    //charge attack
    public float attackTimer;
    public float attackSeconds = 3f;
    public bool chargeAttack;

    public float cooldownTimer;
    public float cooldown = 6f;

    
    void Start()
    {
        //explosionSound = GetComponent<AudioSource>();
        //healthbar = GetComponent<HealthBarScript>();

        timer = seconds;
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

        if (spawned)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                spawned = false;
                timer = seconds;
            }
        }

       

        //if (chargeAttack)
        //{
        //    boss.acceleration = 450;
        //    boss.speed = 100;

        //    if (attackTimer <= 0.0f)
        //    {
        //        chargeAttack = false;
        //        cooldownTimer = cooldown;

        //    }
            
        //}

        //if(!chargeAttack)
        //{
        //    if (Skull.currentHealth <= 100)
        //    {
        //        boss.acceleration = 450;
        //        boss.speed = 100;
        //    }
        //    else
        //    {
        //        boss.acceleration = 100;
        //        boss.speed = 50;
        //    }

        //    cooldownTimer -= Time.deltaTime;
        //    if (cooldownTimer <= 0.0f)
        //    {
        //        chargeAttack = true;
        //        attackTimer = attackSeconds;
                
        //    }

           
        //}
    }




    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform == playerModel)
        {
            if (!spawned)
            {
                Instantiate(enemySpawn, transform.position, transform.rotation);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                Instantiate(explosionParticles, transform.position, transform.rotation);
                spawned = true;
            }
    

        }


    }

    void Die()
    {
        Instantiate(explosionParticles, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Destroy(gameObject);
    }
}

