using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBullet : MonoBehaviour
{
    float waitTime = 3.0f;
    float timer;
    public Rigidbody arrow;
    public bool hitSomething = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(arrow.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(arrow.velocity);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter(Collision col)
    {

    
        if (col.gameObject.tag == "floor")
        {
            Destroy(gameObject);
          
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
          
        }
    }

    private void Stick()
    {
        arrow.constraints = RigidbodyConstraints.FreezeAll;
    }
}
