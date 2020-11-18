using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public Dictionary<string, Queue<GameObject>> pooledObjects = new Dictionary<string, Queue<GameObject>>(); 
    private bool destroyed = false;

    void Awake()
    {
        SharedInstance = this;
    }

    void AddObjects(GameObject objectToPool)
    { 
        Queue<GameObject> objPool = new Queue<GameObject>();
        var obj = GameObject.Instantiate(objectToPool);
        obj.transform.parent = transform;
        obj.SetActive(false);
        objPool.Enqueue(obj);
        if(pooledObjects.ContainsKey(objectToPool.tag))
        {
            pooledObjects[objectToPool.tag].Enqueue(obj);
        }
        else
        {
            pooledObjects.Add(objectToPool.tag, objPool);    
        }
    }
    
    public GameObject GetPooledObject(GameObject objectToPool)
    {
        if(!pooledObjects.ContainsKey(objectToPool.tag)){
            AddObjects(objectToPool);
        }
        else
        {
            if(pooledObjects[objectToPool.tag].Count == 0)
            {
                AddObjects(objectToPool);
            }
        }
        return pooledObjects[objectToPool.tag].Dequeue();
    }

    public void ReturnToPool(GameObject objToPool)
    {
        objToPool.SetActive(false);
        pooledObjects[objToPool.tag].Enqueue(objToPool);
    }

    public IEnumerator ReturnToPool(GameObject objToPool, float duration)
    {
        if(destroyed){
            yield return null;
        }
        if(!destroyed){
            destroyed = true;
            yield return new WaitForSeconds(duration);
            objToPool.SetActive(false);
            pooledObjects[objToPool.tag].Enqueue(objToPool);  
            destroyed = false;        
        }
    }
} 