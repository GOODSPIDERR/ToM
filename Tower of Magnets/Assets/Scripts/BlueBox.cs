using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    private bool magnetized;
    private Rigidbody2D rb;
    private Vector2 difference;
    private float initialGravityScale;
    public bool hasRb;
    public bool lever;
    public bool tripped;
    public bool on;
    void Start()
    {
        if (hasRb)
        {
            rb = GetComponent<Rigidbody2D>();
            initialGravityScale = rb.gravityScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetized)
        {
            var mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            difference = mousePosition - new Vector2(transform.position.x, transform.position.y);
        }

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FixedUpdate()
    {
        if (magnetized && hasRb)
        {
            rb.AddForce(difference * 25f);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Blue box clicked.");
        magnetized = true;
        if (hasRb) rb.gravityScale = 0f;
    }
    
    private void OnMouseUp()
    {
        Debug.Log("Blue box unclicked.");
        magnetized = false;
        if (hasRb) rb.gravityScale = initialGravityScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Off"))
        {
            if (tripped)
            {
                tripped = false;
            }

            else
            {
                on = false;
            }
        }
        
        else if (other.gameObject.CompareTag("On"))
        {
            if (!tripped) on = true;
        }
    }
}
