using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 20;
    public float speed = 6f;
    public float rate = 0.5f;
    public float limite = 2f;
    
    [HideInInspector]
    public GameObject shooter;
    private float y;

    void Start()
    {
        var x = shooter.GetComponent<PlayerCharacter>();
        y = x.Flip() ? -1:1;
        GetComponent<SpriteRenderer>().flipY = x.Flip();
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy en = hitInfo.GetComponent<Enemy>();
        //GameObject.Destroy(gameObject);
        if(en != null)
        {
            en.TakeDamage(damage);
        }
        ObjectPool.SharedInstance.ReturnToPool(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.right * y * Time.deltaTime * speed, Space.World);
    }
}
