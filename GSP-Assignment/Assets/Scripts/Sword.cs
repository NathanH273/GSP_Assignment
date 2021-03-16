using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sword : MonoBehaviour
{
    public Transform Swords;
    public GameObject Enemy;
    public GameObject Pivot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Swords.transform.Rotate(0, -110, 0, Space.Pivot);
        }
       // Swords.transform.Rotate(0, 110, 0, Space.Pivot);
    }


    void OnCollisionEnter(Collision enemy)
    {
        Debug.Log("Hit");
    }
}