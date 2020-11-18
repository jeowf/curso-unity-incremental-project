using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public Dictionary<string, Queue<GameObject>> pooledObjects = new Dictionary<string, Queue<GameObject>>(); 
    
    void Awake()
    {
        SharedInstance = this;
    }

    void AddObjects(string tag, GameObject objectToPool)
    { 
        Queue<GameObject> objPool = new Queue<GameObject>();
        var obj = GameObject.Instantiate(objectToPool);
        obj.transform.parent = transform;
        obj.SetActive(false);
        objPool.Enqueue(obj);
        if(pooledObjects.ContainsKey(tag))
        {
            pooledObjects[tag].Enqueue(obj);
        }
        else
        {
            pooledObjects.Add(tag, objPool);    
        }
    }
    
    public GameObject GetPooledObject(string tag, GameObject objectToPool)
    {
        if(!pooledObjects.ContainsKey(tag)){
            AddObjects(tag, objectToPool);
        }
        else
        {
            if(pooledObjects[tag].Count == 0)
            {
                AddObjects(tag, objectToPool);
            }
        }
        return pooledObjects[tag].Dequeue();
    }

    public void ReturnToPool(GameObject objToPool)
    {
        objToPool.SetActive(false);
        pooledObjects[objToPool.tag].Enqueue(objToPool);
    }

    public IEnumerator ReturnToPool(GameObject objToPool, float duration)
    {
        yield return new WaitForSeconds(duration);
        objToPool.SetActive(false);
        pooledObjects[objToPool.tag].Enqueue(objToPool);          
    }
} 