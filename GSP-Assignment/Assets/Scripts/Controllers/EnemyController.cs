using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;


    //Interact with player in game. (model)
    Transform player;

    NavMeshAgent enemy; 

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player.transform; 
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()   
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            enemy.SetDestination(player.position);
        }

    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

  
}
