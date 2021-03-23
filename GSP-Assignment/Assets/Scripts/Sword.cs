using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sword : MonoBehaviour
{
    public Transform Swords;
    public GameObject Enemy;
    float swingRate = 0.5f;
    float nextSwing = 0.0f;
    bool collisionEnable = false;
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(1)) && (Time.time > nextSwing))
        {
            Swords.transform.Rotate(0, -110, 0, Space.Self);
            nextSwing = Time.time + swingRate;
            collisionEnable = true;
        }

    }
    

    void OnCollisionEnter(Collision enemy)
    {
        if (collisionEnable == true)
        {
            Debug.Log("Hits");
            collisionEnable = false;
        }
    }
}