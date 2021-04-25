using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeHUD : MonoBehaviour
{
    //HUD
    public GameObject hud;
    //Text
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;

    //Timer
    public float timer;
    public float cooldown = 2.0f;
    public bool itemPickup;

    //Set Text
    public void SetTitle(string itemTitle)
    {
        title.text = itemTitle;
    }

    public void SetDesc(string itemDesc)
    {
        desc.text = itemDesc;
    }
    void Start()
    {
        hud.SetActive(false);
        timer = cooldown; 
    }

    void Update()
    {
        if(itemPickup)
        {

            timer -= Time.deltaTime;

            if (timer < 0)
            {
                hud.SetActive(false);
                itemPickup = false;
                timer = cooldown;
            }
        }
        
    }

}
