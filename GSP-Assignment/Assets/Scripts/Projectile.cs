using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Assign these
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemy;

    //Stats
    public bool useGravity;
    public int damage;

    int collisions;
    PhysicMaterial physics_mat;

    private void Setup()
    {
        physics_mat = new PhysicMaterial();
    }



}
