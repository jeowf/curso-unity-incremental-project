using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D rb;

    private Vector2 minCamera;
    private Vector2 maxCamera;

    private Vector2 inputDirection;
    void Start()
    {
        minCamera = CameraExtensions.BoundsMin(Camera.main);
        maxCamera = CameraExtensions.BoundsMax(Camera.main);

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection = input.normalized;

    }

    void FixedUpdate()
    {
        
        if (BoundsCheck(inputDirection))
            rb.MovePosition(rb.position + inputDirection * Time.deltaTime * speed);

    }

    private bool BoundsCheck(Vector2 input)
    {
        Vector2 toPos = new Vector2(transform.position.x, transform.position.y) + input * 0.1f;
        return toPos.x > minCamera.x &&
               toPos.x < maxCamera.x &&
               toPos.y > minCamera.y &&
               toPos.y < maxCamera.y;
    }
}
