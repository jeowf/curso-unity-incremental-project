using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    public List<ShipProjectile> projectiles;

    public AudioClip bullet2;
    
    private int selectedType = 0;

    private bool shooted = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            StartCoroutine(Shoot());
   
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedType = (selectedType + 1) % projectiles.Count;
            AudioClip aux = GetComponent<AudioSource>().clip;
            GetComponent<AudioSource>().clip = bullet2;
            bullet2 = aux;
        }
    }

    public IEnumerator Shoot()
    {
        float t = projectiles[selectedType].rate;
        if (shooted)
            yield return null;
        if (!shooted)
        {
            shooted = true;
            yield return new WaitForSeconds(t);
            //GameObject proj = GameObject.Instantiate(projectiles[selectedType].gameObject) as GameObject;
            GameObject proj = ObjectPool.SharedInstance.GetPooledObject(projectiles[selectedType].gameObject);
            GetComponent<AudioSource>().Play();
            proj.transform.position = transform.position;
            proj.transform.rotation = transform.rotation;
            proj.SetActive(true);
            shooted = false;
        }

    }
}
