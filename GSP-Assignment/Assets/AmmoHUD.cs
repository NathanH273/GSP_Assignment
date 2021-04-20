using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmoHUD : MonoBehaviour
{
    //Player
    public GunV2 gun;

    //Text
    public TextMeshProUGUI text;


    public void SetAmmo(int ammo, int maxAmmo)
    {
        text.text = ammo + "/" + maxAmmo;
    }


}
