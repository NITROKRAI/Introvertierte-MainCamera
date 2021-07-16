using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float health = 3;
    public float fireRate = 0.75f;
    public float timeTillNextShot = 0;
    public GameObject bulletSpawnPoint;
    public Transform target;
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
        if(Time.time >= timeTillNextShot)
        {
            Shoot();
        }
    }
    void FixedUpdate()
    {
        transform.LookAt(target);
    }
    
    void OnParticleCollision(GameObject other)
    {
         if(other.tag == "Bullet Particle")
         {
            health -= 1;
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
