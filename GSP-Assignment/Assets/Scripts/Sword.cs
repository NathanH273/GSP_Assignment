using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sword : MonoBehaviour
{
    public Transform Sword;
    public GameObject Enemy;
    public GameObject Pivot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sword.transform.Rotate(0, -110, 0, Space.Pivot);
        }
        Sword.transform.Rotate(0, 110, 0, Space.Pivot);
    }


    void OnCollisionEnter(Collision enemy)
    {
        Debug.Log("Hit");
    }
}