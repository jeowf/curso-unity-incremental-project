using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Transform asteroid;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<Transform> ();
        
    }

    void FixedUpdate()
    {
        asteroid.position += Vector3.up * speed * -1;
        if(asteroid.position.y <= -9f){
            //Destroy (gameObject);
            //ObjectPool.SharedInstance.returnToPool(gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
        }
        else if(other.tag == "Enemy")
        {
            ObjectPool.SharedInstance.ReturnToPool(other.gameObject);
        }
    }
}
