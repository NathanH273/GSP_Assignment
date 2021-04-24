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

    //Stuff so it doesn't bug out and give player more than intended 
    public bool hasEntered;
    void Start()
    {
        playerModel = GameObject.Find("Player").transform;
        gun = GameObject.Find("Magnum_Revolver").GetComponent<GunV2>();
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
            hasEntered = true;
            gun.maxAmmo += 2;
            Destroy(gameObject);

        }
     
    }
}
