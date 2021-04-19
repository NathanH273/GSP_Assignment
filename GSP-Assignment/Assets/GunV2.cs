using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunV2 : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;

    public Camera cam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            

            if (target != null)
            {
                target.takeDamage(damage);
       
            }

            
            //if (rangedEnemy != null)
            //{
            //    rangedEnemy.takeDamage(damage);
            //}

           // Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }

    }


}
