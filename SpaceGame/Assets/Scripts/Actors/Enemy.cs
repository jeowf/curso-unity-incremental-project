using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private PlayerCharacter playerScript;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private bool dealtDamage = false;
    private AudioSource audio;

    public float damage =5f;
    public float health = 100;
    public float speed = 5f;
    public float distFollow = 15f;
    public int pointsWorth = 10;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    IEnumerator OnTriggerStay2D (Collider2D hitInfo)
    {
        PlayerCharacter player = hitInfo.GetComponent<PlayerCharacter>();
        //GameObject.Destroy(gameObject);
        if(dealtDamage)
        {
            yield return null;
        }
        if(player != null && !dealtDamage)
        {
            dealtDamage = true;
            yield return new WaitForSeconds(0.5f);
            player.TakeDamage(damage);
            dealtDamage = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        audio.Play();
        if(health <= 0)
        {
            anim.SetBool("Dead", true);
            playerScript.RaisePoints(pointsWorth);
            Destroy(gameObject, 1f);
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
