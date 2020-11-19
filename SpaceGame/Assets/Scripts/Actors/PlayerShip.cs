using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public float speed = 1f;
    public int health = 100;
    public int Score;
    public HealthBar healthBar;

    private Rigidbody2D rb;

    private Vector2 minCamera;
    private Vector2 maxCamera;

    private Vector2 inputDirection;
    void Start()
    {
        minCamera = CameraExtensions.BoundsMin(Camera.main);
        maxCamera = CameraExtensions.BoundsMax(Camera.main);

        rb = GetComponent<Rigidbody2D>();
        
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection = input.normalized;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
        }
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

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
}
