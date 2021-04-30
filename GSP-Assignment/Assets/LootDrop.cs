﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public Vector3 velocity = Vector3.up;
    private Rigidbody rb;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        velocity *= Random.Range(100f, 200f);
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        rb.position += velocity * Time.deltaTime;

        if (velocity.y < -4f)
        {
            velocity.y = -4f;
        }

        else
        {
            velocity -= Vector3.up * 5 * Time.deltaTime;
        }

        if (Mathf.Abs(rb.position.y - startPosition.y) < 0.25f && velocity.y < 0f)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.velocity = velocity;
            this.enabled = false;
        }
    }
}
