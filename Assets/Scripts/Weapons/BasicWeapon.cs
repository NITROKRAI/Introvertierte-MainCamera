using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicWeapon : Weapon
{
    public GameObject bulletSpawnPoint;
    public GameObject Bullet;
    public float ammo;
    public bool canShoot;
    public bool isShooting;
    public bool isReloading;
    public int BulletsShot;
    public int spreadAngle;
    public bool allowInvoke = true;
    public Rigidbody BulletRB;
    public GameObject[] bulletSpawnPoints = new GameObject[0];
    public ParticleSystem muzleFlash;
    public ParticleSystem BulletCasing;
    public float DamageReference;
    public float BulletDamage;
    public GameObject BulletCasingPosition;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioSource ReloadSound;
    [SerializeField] Sprite WeaponSprite;
    AudioSource audioSource;
    public Image SpriteInHud;
    public Image ReloadInHud;
    public Text ammoDisplay;
    
    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
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
        //if(ammo <= 0)
        //{
        //    Reload();
        //}
        SpriteInHud.sprite = WeaponSprite;
        ReloadInHud.sprite = WeaponSprite;
        ammoDisplay.text = ammo.ToString()+"/"+Data.Ammo;
        ShowReloadInHud();
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
        audioSource.PlayOneShot(ShootSound);
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
    }

    private void ResetShot()
    {
        canShoot = true;
        allowInvoke = true;
    }

    public override void Reload()
    {
        ReloadInHud.fillAmount = 1;
        isReloading = true;
        Invoke("ReloadFinished", Data.ReloadTime);
    }

    void ShowReloadInHud()
    {
        if(isReloading == true)
        {
            Debug.Log("DDDDD");
            ReloadInHud.fillAmount -= 1 / Data.ReloadTime * Time.deltaTime;
        }
        
    }
    private void ReloadFinished()
    {
        //Fill magazine
        ammo = Data.Ammo;
        isReloading = false;
        ReloadSound.Play();
    }
}
