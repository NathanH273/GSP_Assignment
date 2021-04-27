using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootScript : MonoBehaviour
{
    //Text
    public Text prompt;

    //Objects
    public GameObject angel;
    public Transform spawn;

    //Loot
    public List<GameObject> drops;
    public int[] table =
    {
        20, //Jump upgrade
        20, //Reload Speed
        20, //Attack Speed
        20, //Dash Cooldown
        20, //Cloak of Flames upgrade (idk couldn't think of anything)
    };
    public int total;
    public int randomNumber;

    //Player Nearby
    public bool playerNearby; // change to private later




    

    // Start is called before the first frame update
    void Start()
    {
        prompt.enabled = false;
        playerNearby = false;

        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Instantiate(drops[i], spawn);
                return;
            }

            else
            {
                randomNumber -= table[i];
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby)
        {
            prompt.enabled = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "player")
        {
            playerNearby = true;
        }
    }
}
