using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float shotRate = 0.2f;
    float nextShot = 0.0f;
    public Rigidbody bullet;
    public Transform spawnPoint;
    public Transform Target;
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (Time.time > nextShot))
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, Target.position, Target.rotation);
            bulletInstance.AddForce(spawnPoint.forward * 6000f);
            nextShot = Time.time + shotRate;
        }

    }
}
