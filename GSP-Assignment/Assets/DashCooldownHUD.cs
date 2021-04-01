using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownHUD : MonoBehaviour
{
    public Image image;
    public ThirdPersonCharacterController controller;

    void Update()
    {
        float cooldown = controller.dashCooldownDuration;

        if(controller.dashTimer)
        {
            image.fillAmount += 1 / cooldown * Time.deltaTime;

            if(image.fillAmount >= 1)
            {
                image.fillAmount = 0;
            }
        
        }

      
    }

}
