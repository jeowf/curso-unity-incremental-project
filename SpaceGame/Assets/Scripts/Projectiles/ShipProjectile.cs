using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipProjectile : MonoBehaviour
{
    public int damage = 1;
    public float speed = 1f;
    public float rate = 1f;
    public float limite = 2f;
    
    [HideInInspector]
    public GameObject shooter;

    void Start()
    {
        //GameObject.Destroy(gameObject, duration);
    }

    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
        if(transform.position.y >= limite)
            ObjectPool.SharedInstance.ReturnToPool(gameObject);
    }
    /*
    public void Shoot(Vector3 position)
    {
        GameObject proj = GameObject.Instantiate(projectile) as GameObject;
        proj.transform.position = shooter.transform.position;
        proj.transform.rotation = shooter.transform.rotation;

    }
    */
   

}
