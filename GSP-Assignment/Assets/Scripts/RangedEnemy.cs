using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RangedEnemy : MonoBehaviour
{
    //Attributes/stats
    public int maxHealth = 100;
    public int currentHealth;

    //Agent stuff
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask ground, whatIsPlayer;
    public GameObject projectile;

    //Patrolling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attackSpeed;
    bool alreadyAttacked;
    public GameObject bulletSpawn;

    //States
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if(playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
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

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.rotation = Quaternion.LookRotation(agent.velocity);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        bulletSpawn.transform.LookAt(player);



        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, bulletSpawn.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 34f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackSpeed);

        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
