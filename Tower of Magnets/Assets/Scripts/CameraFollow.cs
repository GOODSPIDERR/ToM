using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float positionX;
    private float positionY;

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponentInParent<Transform>();
    }


    private void Update()
    {
        positionX = playerTransform.position.x;
        positionY = playerTransform.position.y;

        positionX = Mathf.Clamp(positionX, 0f, 999f);
        positionY = Mathf.Clamp(positionY, 0.5f, 999f);

        transform.position = new Vector2(positionX, positionY);
    }
}
