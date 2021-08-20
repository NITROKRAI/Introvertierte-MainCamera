using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : Weapon
{
    public GameObject bulletSpawnPoint;
    public GameObject Bullet;
    public float ammo;
    public bool canShoot;
    public bool isShooting;
    float damage;
    float fireRate;
    bool infiniteAmmo;
    float reloadTime;
    float spread;
    bool needsToBeCharged;
    float timeTillNextShot;
    public bool isReloading;
    public int BulletsShot;
    List<Quaternion> Bullets;
    public int spreadAngle;
    public bool allowInvoke = true;
    float randomSpreadY;
    float minSpread = 0.1f;
    float maxSpread = 0.3f;
    public Rigidbody BulletRB;
    public GameObject[] bulletSpawnPoints = new GameObject[0];
    public ParticleSystem muzleFlash;
    public ParticleSystem BulletCasing;
    public float DamageReference;
    public float BulletDamage;
    public GameObject BulletCasingPosition;
    // Start is called before the first frame update
    void Start()
    {

        
        BulletRB = Bullet.GetComponent<Rigidbody>();
        ammo = Data.Ammo;
        canShoot = true;
    }

    // Update is called once per frame
    private void Awake()
    {

    }
    void Update()
    {
        InputCheck();
    }
    void InputCheck()
    {
        if (Input.GetButton("Fire1"))
        {
            isShooting = true;

        }
        else
        {
            isShooting = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo < Data.Ammo && !isReloading)
        {
            Reload();
        }
        if (canShoot && isShooting && !isReloading && ammo <= 0)
        {
            Reload();
        }
        if (canShoot && isShooting && !isReloading && ammo > 0)
        {
            //Set bullets shot to 0
            //bulletsShot = 0;

            Shoot();
        }
    }
    private void FixedUpdate()
    {
     
    }
    public override void Shoot()
    {
        muzleFlash.Play();
        BulletCasing.Play();
        canShoot = false;
        ammo--;
        if (allowInvoke)
        {
            Invoke("ResetShot", Data.FireRate);
            {
                allowInvoke = false;
            }
        }
        for (int d = 0; d < bulletSpawnPoints.Length; d++)
        {
            if (Bullet != null)
            {
            Instantiate(BulletCasing, BulletCasingPosition.transform.position, BulletCasingPosition.transform.rotation);   
            Debug.Log("dick");
            GameObject Bullet = ObjectPool.instance.GetPooledObject();
            Bullet.tag = "Player Bullet";
            DamageReference = Bullet.GetComponent<Bullet>().damage;
            Bullet.transform.position = bulletSpawnPoints[d].transform.position;
            Bullet.transform.rotation = bulletSpawnPoints[d].transform.rotation;
            Bullet.SetActive(true);
            }

        }
        if(Data.ammoCasingAfterEachShot)
        {
            
        }
        
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        canShoot = true;
        allowInvoke = true;
    }
    public override void Reload()
    {
        isReloading = true;
        Invoke("ReloadFinished", Data.ReloadTime);
        if (Data.ejectMagazineOnReload)
        {

        }
    }
    private void ReloadFinished()
    {
        //Fill magazine
        ammo = Data.Ammo;
        isReloading = false;
    }
}
