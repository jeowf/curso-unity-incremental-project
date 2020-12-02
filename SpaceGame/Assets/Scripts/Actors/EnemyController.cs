using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;
    private int contactDamage = 30;
    public float speed;
    //public float next_spawn_time;
    public static float life;
    public static float initLife;
    public float initialLife = 4;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform> ();
        life = initialLife;
        initLife = initialLife;
        //next_spawn_time = Time.time+5.0f;

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
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
            PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();
            if (playerShip != null)
                playerShip.TakeDamage(contactDamage);
            //Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            life = initLife;

            ObjectPool.SharedInstance.ReturnToPool(gameObject);

            scoreManager.IncrementScore(1);
        }
        //ObjectPool.SharedInstance.ReturnToPool(gameObject);
    }
}
