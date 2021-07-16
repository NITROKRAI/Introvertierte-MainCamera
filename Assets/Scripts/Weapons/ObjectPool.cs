using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject poolingObject;
    public List<GameObject> pooledObjects;
    public int poolSize = 100;

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        pooledObjects = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(poolingObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
