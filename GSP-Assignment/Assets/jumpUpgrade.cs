using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpUpgrade : MonoBehaviour
{
    public ThirdPersonCharacterController player;

    void OnCollisionEnter(Collision collision)
    {
        player.jumpUpgrade = true;
        Destroy(gameObject);
    }
}
