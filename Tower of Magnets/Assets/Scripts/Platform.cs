using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Transform playerTransform;
    private BoxCollider2D _boxCollider;


    private void Start()
    {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= playerTransform.position.y && playerRb.velocity.y <= 0f)
            _boxCollider.enabled = true;
        else
        {
            _boxCollider.enabled = false;
        }
    }
}
