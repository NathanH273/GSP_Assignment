using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashUpgrade : MonoBehaviour
{
    //Spin
    public GameObject spin;

    //Upgrading the player
    public ThirdPersonCharacterController player;
    public Transform playerModel;

    //Text
    public UpgradeHUD hud;
    public GameObject hudGameObject;

    //Stuff so it doesn't bug out and give player more than intended 
    public bool hasEntered;

    //Sound
    public AudioClip upgradeSFX;

    void Awake()
    {
        //Player
        playerModel = GameObject.Find("Player").transform;
        player = playerModel.GetComponent<ThirdPersonCharacterController>();

        //HUD
        hudGameObject = GameObject.Find("Upgrade HUD");
        hud = hudGameObject.GetComponent<UpgradeHUD>();


    }

    void Update()
    {
        transform.RotateAround(spin.transform.position, Vector3.up, 77 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == playerModel && !hasEntered)
        {
            //Has entered boolean
            hasEntered = true;

            AudioSource.PlayClipAtPoint(upgradeSFX, transform.position, 1.0f);
            player.dashCooldownDuration -= 1;

            hud.SetTitle("Dash Upgrade");
            hud.SetDesc("Reduced Cooldown on Dash");
            hudGameObject.SetActive(true);
            hud.itemPickup = true;

            Destroy(gameObject);
        }
    }
}
