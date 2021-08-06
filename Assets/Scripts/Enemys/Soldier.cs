using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
   
    public float fireRate = 0.75f;
    public float timeTillNextShot = 0;
    public GameObject bulletSpawnPoint;
  
    void Start()
    {
       
    }

    
    void Update()
    {
        
        if(Time.time >= timeTillNextShot)
        {
            Shoot();
        }
    }
    

    public void Shoot()
    {
        timeTillNextShot = Time.time + fireRate;
        GameObject Bullet = ObjectPool.instance.GetPooledObject();
        if(Bullet != null) 
        {
        Bullet.tag = "Enemy Bullet";
        Bullet.transform.position = bulletSpawnPoint.transform.position;
        Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        Bullet.SetActive(true);
        }          
    }
}
