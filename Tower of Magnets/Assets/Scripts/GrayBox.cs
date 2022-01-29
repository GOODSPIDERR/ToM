using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayBox : MonoBehaviour
{
    private bool magnetized;
    private Rigidbody2D rb;
    private Vector2 difference;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetized)
        {
            difference = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y);
        }

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FixedUpdate()
    {
        if (magnetized)
        {
            rb.AddForce(difference * 5f);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Blue box clicked.");
        magnetized = true;
        rb.gravityScale = 0f;
    }
    
    private void OnMouseUp()
    {
        Debug.Log("Blue box unclicked.");
        magnetized = false;
        rb.gravityScale = 1f;
    }
}
