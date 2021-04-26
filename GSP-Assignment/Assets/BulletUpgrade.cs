using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour
{
    //Spin animation
    public GameObject target;

    //Upgrading the player
    public Transform playerModel;
    public GunV2 gun;

    //Text
    public UpgradeHUD hud;
    public GameObject hudGameObject;

    //Stuff so it doesn't bug out and give player more than intended 
    public bool hasEntered;

    //Sound
    public AudioClip upgradeSFX;

    void Awake()
    {
        playerModel = GameObject.Find("Player").transform;
        gun = GameObject.Find("Magnum_Revolver").GetComponent<GunV2>();

        //HUD
        hudGameObject = GameObject.Find("Upgrade HUD");
        hud = hudGameObject.GetComponent<UpgradeHUD>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 77 * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == playerModel && !hasEntered)
        {
            AudioSource.PlayClipAtPoint(upgradeSFX, transform.position, 0.5f);

            //Has entered boolean
            hasEntered = true;

            //Upgrade
            gun.maxAmmo += 2;
            gun.currentAmmo = gun.maxAmmo;

            //HUD
            hud.SetTitle("Ammo Capacity Max Upgrade");
            hud.SetDesc("+2 on Max Ammo!");
            hudGameObject.SetActive(true);  
            hud.itemPickup = true;

            //Destroy the gameobject
            Destroy(gameObject);

        }
     
    }
}
