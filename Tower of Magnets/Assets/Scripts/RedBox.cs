using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RedBox : MonoBehaviour
{
    public Transform circle;
    private CircleCollider2D circleCollider;
    private ForceField circleForceField;
    private SpriteRenderer circleSprite;
    void Start()
    {
        circleCollider = circle.GetComponent<CircleCollider2D>();
        circleForceField = circle.GetComponent<ForceField>();
        circleSprite = circle.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Red box unclicked.");
            circle.DOScale(new Vector3(1, 1, 1), 0.25f);
            circleCollider.enabled = false;
        }
    }
    
    private void OnMouseDown()
    {
        Debug.Log("Red box clicked.");
        circle.DOScale(new Vector3(10, 10, 1), 0.25f);
        circleCollider.enabled = true;
        circleForceField.red = false;
        circleSprite.color = Color.blue;
    }
    
    private void OnMouseUp()
    {
        Debug.Log("Red box unclicked.");
        circle.DOScale(new Vector3(1, 1, 1), 0.25f);
        circleCollider.enabled = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Red box clicked.");
            circle.DOScale(new Vector3(10, 10, 1), 0.25f);
            circleCollider.enabled = true;
            circleForceField.red = true;
            circleSprite.color = Color.red;
        }
    }
}
