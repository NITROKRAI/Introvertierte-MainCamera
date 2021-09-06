using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject PoolingObject;
    public List<GameObject> PooledObjects;
    public int poolSize = 100;

    void Awake()
    { 
        instance = this;
        PooledObjects = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(PoolingObject);
            obj.SetActive(false);
            PooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
    }
}
