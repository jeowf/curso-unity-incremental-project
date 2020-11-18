using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float movementSpeed = 340f;
    // Modificação do jump
    public float jumpSpeed = 120000f;
    public LayerMask groundColision;
    public float groundThresh = 0.2f;
    // Fim modificação do jump

    private SpriteRenderer _sr;
    private Animator _anim;
    private CapsuleCollider2D _capsule;
    private Rigidbody2D _rb;

    private bool _flip = false;

    private float _horizontal;
    private float _vertical;
    // Modificação do jump
    private bool _jump;
    private bool _grounded;
    // Fim modificação do jump

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
        

        // Modificação do jump
        if(Input.GetKeyDown("w"))
        {
            _jump = true;
        }
        // Fim modificação do jump

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
        //Script do pulo
        _grounded = Physics2D.Raycast(transform.position, -Vector3.up, groundThresh,groundColision);

        if(_jump && _grounded)
        {
            _rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Force);
            _jump = false;
        }
        // Fim do script do pulo

        //_rb.MovePosition(_rb.position + )
        if (_horizontal != 0)
            _rb.AddForce(Vector2.right * _horizontal * movementSpeed * Time.deltaTime, ForceMode2D.Force);

        _anim.SetFloat("Speed", Mathf.Abs(_horizontal));
        _anim.SetFloat("HorizontalVelocity", Mathf.Abs(_rb.velocity.x));
    }
}
