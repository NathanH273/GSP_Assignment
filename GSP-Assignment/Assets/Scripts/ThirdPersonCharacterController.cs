using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    //Movement Values
    public float speed; 
    public float jumpForce;
    public float dashForce;
    public bool dashTimer = false;
    public int dashCooldownDuration;

    public bool isOnGround = true;
    public int noOfJumps;
    public Rigidbody rb;
    public bool jumpUpgrade= false;

    public Vector3 pos;



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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !dashTimer )
        {
            StartCoroutine(dashCoolDown(dashCooldownDuration));
            Dash();
            dashTimer = true;
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isOnGround = true; 
        }
    }

    void Dash()
    {
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
    }

    IEnumerator dashCoolDown(int dashCoolDownDuration)
    {
        yield return new WaitForSeconds(dashCoolDownDuration);
        Debug.Log("dash can now be used again.");
        dashTimer = false;

    }
}
