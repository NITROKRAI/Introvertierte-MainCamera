using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public GameObject bulletSpawnPoint;
    public GameObject Bullet;
    float ammo;
    float damage;
    float fireRate;
    bool infiniteAmmo;
    float reloadTime;
    float spread;
    bool needsToBeCharged;
    float timeTillNextShot;
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && fireRate >= Data.FireRate)
        {
            Shoot();
        }
        fireRate += Time.fixedDeltaTime;
    }
    public override void Shoot()
    {
        fireRate = 0;

        GameObject Bullet = ObjectPool.instance.GetPooledObject();
        if (Bullet != null)
        {
            Bullet.tag = "Player Bullet";
            Bullet.transform.position = bulletSpawnPoint.transform.position;
            Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
            Bullet.SetActive(true);
        }
    }
    public override void Reload()
    {

    }
}
