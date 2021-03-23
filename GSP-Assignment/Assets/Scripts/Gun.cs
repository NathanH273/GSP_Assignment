using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float shotRate = 0.2f;
    float nextShot = 0.0f;
    public Rigidbody bullet;
    public Transform spawnPoint;

    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (Time.time > nextShot))
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            bulletInstance.AddForce(spawnPoint.forward * 3000f);
            nextShot = Time.time + shotRate;
        }

    }
}
