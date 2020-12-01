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

    public float vida = 50f;
    public int pontuacao;
    public HealthBar healthBar;
    public UIScore uIScore;
    public GameObject aterrisar;
    public GameObject pulo;
    public GameObject MorteAudio; 
    private SpriteRenderer _sr;
    private Animator _anim;
    private CapsuleCollider2D _capsule;
    private Rigidbody2D _rb;
    private AudioSource _audio;
    private AudioSource _aterrisar;
    private AudioSource _pulo;
    private AudioSource _MorteAudio;

    private bool _flip = false;

    private float _horizontal;
    //private float _vertical;
    // Modificação do jump
    //private bool _jump;
    private bool _grounded;
    //private bool _afloat;
    // Fim modificação do jump

    public void RaisePoints(int pontos)
    {
        pontuacao += pontos;
        uIScore.UpdateText(pontuacao);
    }

    public void TakeDamage(float dano)
    {
        vida -= dano;
        healthBar.SetHealth(vida);

        if(vida <= 0)
        {
            _MorteAudio.Play();
            Destroy(gameObject, 0.5f);
            
        }
    }

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _aterrisar = aterrisar.GetComponent<AudioSource>();
        _pulo = pulo.GetComponent<AudioSource>();
        _MorteAudio = MorteAudio.GetComponent<AudioSource>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _capsule = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        pontuacao = 0;
        healthBar.SetMaxHealth(vida);
        uIScore.UpdateText(pontuacao);
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        //_vertical = Input.GetAxis("Vertical");
        

        // Modificação do jump
        //if(Input.GetKeyDown("w"))
        //{
        //    _jump = true;
        //}
        // Fim modificação do jump

        if (_horizontal < 0 && !_flip)
        {
            transform.Rotate(0f, 180f, 0f);
            //_sr.flipX = true;
            _flip = true;
        }
        else if (_horizontal > 0 && _flip)
        {
            //_sr.flipX = false;
            transform.Rotate(0f, -180f, 0f);
            _flip = false;
        }
    }

    public bool Flip()
    {
        return _flip;
    }

    void FixedUpdate()
    {
        _audio.UnPause();
        if (_horizontal != 0)
        {
            _rb.AddForce(Vector2.right * _horizontal * movementSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        else
        {   
            _audio.Pause();            
        }
        //Script do pulo
        Debug.DrawRay(transform.position, -Vector3.up * groundThresh, Color.red);
        _grounded = Physics2D.Raycast(transform.position, -Vector3.up, groundThresh,groundColision);

        if (Input.GetKey(KeyCode.W) && _grounded)
        {
            _audio.Pause();
            _pulo.Play();
            //_rb.AddForce(Vector2.up * jumpSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }

        if (!_grounded) {
            _audio.Pause();
            _anim.SetBool("Jumping", true);
            _aterrisar.Play();
            //_afloat = true;
        }
        else
        {
            //_afloat = false;
            _anim.SetBool("Jumping", false);
        }
        // Fim do script do pulo

        //_rb.MovePosition(_rb.position + )
        
            

        _anim.SetFloat("VerticalVelocity", Mathf.Abs(_rb.velocity.y));
        _anim.SetFloat("Speed", Mathf.Abs(_horizontal));
        _anim.SetFloat("HorizontalVelocity", Mathf.Abs(_rb.velocity.x));
    }
}
