using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordStuff : MonoBehaviour
{
    [SerializeField] public Transform Sword;
    [SerializeField] public GameObject Enemy;
    [SerializeField] public GameObject Pivot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Sword.transform.Rotate(0, -110, 0, Space.Pivot);
        }
        Sword.transform.Rotate(0, 0, 0, Space.Pivot);
    }


    void OnCollisionEnter(Collision enemy)
    {
        Debug.Log("Hit");
    }
}
