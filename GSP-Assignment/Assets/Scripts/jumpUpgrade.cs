using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpUpgrade : MonoBehaviour
{
    //Player
    public ThirdPersonCharacterController player;
    public Transform playerModel;

    //HUD
    public GameObject hudGameObject;
    public UpgradeHUD hudScript;

    void Awake()
    {
        //Player
        playerModel = GameObject.Find("Player").transform;
        player = playerModel.GetComponent<ThirdPersonCharacterController>();

        //HUD
        hudGameObject = GameObject.Find("Upgrade HUD");
        hudScript = hudGameObject.GetComponent<UpgradeHUD>();


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == playerModel)
        {
            player.jumpUpgrade = true;
            
            hudScript.SetTitle("Double Jump Upgrade");
            hudScript.SetDesc("You can now double jump.");
            hudGameObject.SetActive(true);
            hudScript.itemPickup = true;

            Destroy(gameObject);
        }
    }
}
