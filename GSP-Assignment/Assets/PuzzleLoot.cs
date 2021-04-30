using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLoot : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables
    public float radius = 3f;

    //Text
    public Text prompt;

    //Objects
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

    private bool puzzleCompleted = false;


    //Animator
    public Animator animator;





    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


    }

    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void DisplayText()
    {
        prompt.enabled = true;
    }

    public void GiveUpgrade()
    {
        animator.SetBool("openChest", true);
        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                if (!puzzleCompleted)
                {
                    puzzleCompleted = true;
                    Instantiate(drops[i], spawn.transform.position, Quaternion.identity);
                }
                return;
            }
             
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
