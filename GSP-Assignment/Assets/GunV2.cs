
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunV2 : MonoBehaviour
{
    //Gun 
    public int damage = 10;
    public float range = 55f;
    public float fireRate = 15f;

    //Ammo
    public int maxAmmo = 6;
    public int currentAmmo;
    public float reloadTime = 1f;

    //Misc
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem impactEffect;
    public AudioClip gunShotSFX;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    //Anim
    public Animator animator;

    //HUD
    public AmmoHUD ammoHud;

    void Start()
    {
        currentAmmo = maxAmmo;
        ammoHud.SetAmmo(currentAmmo, maxAmmo);

    }

    void onEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        ammoHud.SetAmmo(currentAmmo, maxAmmo);

        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown("r") && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

     
    }
    void Shoot()
    {
        currentAmmo--;


        muzzleFlash.Play();
        AudioSource.PlayClipAtPoint(gunShotSFX, transform.position, 0.5f);

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

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading..");

        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);
        
        currentAmmo = maxAmmo;
        isReloading = false;
    }


}
