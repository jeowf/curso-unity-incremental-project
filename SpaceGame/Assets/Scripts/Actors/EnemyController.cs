using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;
    public float speed;
    //public float next_spawn_time;
    public static float life = 3;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform> ();
        //next_spawn_time = Time.time+5.0f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.position += Vector3.up * speed * -1;
        if(enemy.position.y <= -7f){
            ObjectPool.SharedInstance.ReturnToPool(gameObject);   
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
            Destroy(other.gameObject);
        
        }
    }
}
