using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator LeftDoor;
    public Animator RightDoor;
    public DoorTrigger trigger;

    public float timer = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.playerEnter)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        LeftDoor.SetBool("openDoor", true);
        RightDoor.SetBool("openDoor", true);

    }

    public void CloseDoor()
    {
        LeftDoor.SetBool("openDoor", false);
        RightDoor.SetBool("openDoor", false);

    }
}
