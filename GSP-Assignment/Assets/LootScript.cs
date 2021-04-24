using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootScript : MonoBehaviour
{
    public Text text;

    public int[] table =
    {
        20, //Jump upgrade
        20, //Reload Speed
        20, //Attack Speed
        20, //Dash Cooldown
        20, //Cloak of Flames upgrade (idk couldn't think of anything)
    };

    public bool playerNearby; // change to private later

    

    // Start is called before the first frame update
    void Start()
    {
        playerNearby = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
