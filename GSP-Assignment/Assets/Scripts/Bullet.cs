using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer;
    float waitTime = 4.0f;

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }


}
