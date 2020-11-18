using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float movementSpeed = 340f;

    private SpriteRenderer _sr;
    private Animator _anim;
    private CapsuleCollider2D _capsule;
    private Rigidbody2D _rb;

    private bool _flip = false;

    private float _horizontal;
    private float _vertical;

    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _capsule = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");


        if (_horizontal < 0 && !_flip)
        {
            _sr.flipX = true;
            _flip = true;
        }
        else if (_horizontal > 0 && _flip)
        {
            _sr.flipX = false;
            _flip = false;
        }
    }

    void FixedUpdate()
    {
        //_rb.MovePosition(_rb.position + )
        if (_horizontal != 0)
            _rb.AddForce(Vector2.right * _horizontal * movementSpeed * Time.deltaTime, ForceMode2D.Force);

        _anim.SetFloat("Speed", Mathf.Abs(_horizontal));
        _anim.SetFloat("HorizontalVelocity", Mathf.Abs(_rb.velocity.x));
    }
}
