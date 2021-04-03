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

    //Patrolling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float attackSpeed;
    bool alreadyAttacked;

    //States
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

}
