using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    //Movement Values
    public float speed; 
    public float jumpForce; 

    public bool isOnGround = true;
    public int noOfJumps;
    public Rigidbody rb;
    public bool jumpUpgrade= false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if(isOnGround) 
        {
            if (jumpUpgrade == true)
            {
                noOfJumps = 2;
            }
            else
            {
                noOfJumps = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && noOfJumps > 0)
        {
            isOnGround = false;
            noOfJumps--;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }            


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isOnGround = true; 
        }
    }
}
