using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public LayerMask ground, whatIsPlayer;
    public NavMeshAgent agent;

    //Patrolling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public float sightRange;
    public float attackRange;



    void Start()
    {
        //explosionSound = GetComponent<AudioSource>();
        //healthbar = GetComponent<HealthBarScript>();

        agent = GetComponent<NavMeshAgent>();
        EnemyController enemyScript = GetComponent<EnemyController>();
        playerModel = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        

 

    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        else if (playerModel != null && enemyScript.lookRadius <= enemyScript.distance)
        {
            transform.LookAt(playerModel);
        }

        if (Skull.currentHealth <= 0)
        {
            //Debug.Log("Dead");
            Die();
        }
    }


    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        transform.rotation = Quaternion.LookRotation(agent.velocity);

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
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
        Destroy(gameObject);
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, ground))
        {
            walkPointSet = true;
        }

    }

}

