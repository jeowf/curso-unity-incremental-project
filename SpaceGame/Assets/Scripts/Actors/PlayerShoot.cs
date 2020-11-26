using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerProjectile projectile;
    public Transform firePoint;
    private Animator _anim;

    private bool shooted = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _anim.SetBool("Shooting", true);
            StartCoroutine(Shoot());
        }
        else
        {
            _anim.SetBool("Shooting", false);
        }
    }

    public IEnumerator Shoot()
    {
        float t = projectile.rate;
        if (shooted)
            yield return null;
        if (!shooted)
        {
            shooted = true;
            yield return new WaitForSeconds(t);
            //GameObject proj = GameObject.Instantiate(projectiles[selectedType].gameObject) as GameObject;
            GameObject proj = ObjectPool.SharedInstance.GetPooledObject(projectile.gameObject);
            proj.transform.position = firePoint.position;
            proj.GetComponent<PlayerProjectile>().shooter = gameObject;
            proj.SetActive(true);
            shooted = false;
        }

    }
}
