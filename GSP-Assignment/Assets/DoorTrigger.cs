using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool playerEnter;
    public int enemyAmount;

    void Awake()
    {
        playerEnter = false;

    }

    void Update()
    {

        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            playerEnter = true;
        }

        if (collider.tag == "enemy")
        {
            enemyAmount++;
        }



    }

    void OnTriggerExit(Collider enemy)
    {
        enemyAmount--;
    }
}
