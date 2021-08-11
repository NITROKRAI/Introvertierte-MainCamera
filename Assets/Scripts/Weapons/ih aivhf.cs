using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletSpawnPoint;
    public GameObject Bullet;
    public float fireRate = 0.75f;
    public float timeTillNextShot = 0;
    public GameObject WeaponDropPoint;
    public GameObject weaponDrop;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void FixedUpdate()
    {
        
    }

    private void Shoot()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeTillNextShot)
        {
            
            //Instantiate(Bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            //Objectpool variante von instantiate
            GameObject Bullet = ObjectPool.instance.GetPooledObject();
            if(Bullet != null) 
            {
                Bullet.tag = "Player Bullet";
                Bullet.transform.position = bulletSpawnPoint.transform.position;
                Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
                Bullet.SetActive(true);
            }
            timeTillNextShot = Time.time + fireRate;          
        }
    }
}
