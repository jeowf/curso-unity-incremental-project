using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    public float health = 100;
    public float speed = 5f;
    public float distFollow = 15f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            anim.SetBool("Dead", true);
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if((player.position.x - rb.position.x) > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if(Vector2.Distance(player.position, rb.position) < distFollow)
        {
            anim.SetBool("Following", true);
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            anim.SetBool("Following", false);
        }
        
    }
}
