using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public bool red;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var rb = other.GetComponent<Rigidbody2D>();
            if (!red)
                rb.AddForce((new Vector2(transform.position.x, transform.position.y) - rb.position) * 10f);
            else
            {
                rb.AddForce((rb.position - new Vector2(transform.position.x, transform.position.y)) * 10f);
            }
        }
    }
}
