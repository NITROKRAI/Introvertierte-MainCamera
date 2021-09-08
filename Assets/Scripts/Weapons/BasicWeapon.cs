using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicWeapon : Weapon
{
    public GameObject BulletSpawnPoint;
    public GameObject Bullet;
    public float Ammo;
    public bool CanShoot;
    public bool IsShooting;
    public bool IsReloading;
    public int BulletsShot;
    public bool AllowInvoke = true;
    public Rigidbody BulletRB;
    public GameObject[] BulletSpawnPoints = new GameObject[0];
    public ParticleSystem MuzleFlash;
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
    public Text AmmoDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BulletRB = Bullet.GetComponent<Rigidbody>();
        Ammo = Data.Ammo;
        CanShoot = true;
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
        AmmoDisplay.text = Ammo.ToString()+"/"+Data.Ammo;
        ShowReloadInHud();
        InputCheck();
    }

    void InputCheck()
    {
        if (Input.GetButton("Fire1"))
        {
            IsShooting = true;

        }
        else
        {
            IsShooting = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && Ammo < Data.Ammo && !IsReloading)
        {
            Reload();
        }
        if (CanShoot && IsShooting && !IsReloading && Ammo <= 0)
        {
            Reload();
        }
        if (CanShoot && IsShooting && !IsReloading && Ammo > 0)
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
        MuzleFlash.Play();
        BulletCasing.Play();
        CanShoot = false;
        Ammo--;
        if (AllowInvoke)
        {
            Invoke("ResetShot", Data.FireRate);
            {
                AllowInvoke = false;
            }
        }
        for (int d = 0; d < BulletSpawnPoints.Length; d++)
        {
            if (Bullet != null)
            {
            Instantiate(BulletCasing, BulletCasingPosition.transform.position, BulletCasingPosition.transform.rotation);   
            GameObject Bullet = ObjectPool.instance.GetPooledObject();
            Bullet.tag = "Player Bullet";
            Bullet.transform.position = BulletSpawnPoints[d].transform.position;
            Bullet.transform.rotation = BulletSpawnPoints[d].transform.rotation;
            Bullet.SetActive(true);
            }

        }
    }

    private void ResetShot()
    {
        CanShoot = true;
        AllowInvoke = true;
    }

    public override void Reload()
    {
        ReloadInHud.fillAmount = 1;
        IsReloading = true;
        Invoke("ReloadFinished", Data.ReloadTime);
    }

    void ShowReloadInHud()
    {
        if(IsReloading == true)
        {
            ReloadInHud.fillAmount -= 1 / Data.ReloadTime * Time.deltaTime;
        }
        
    }
    private void ReloadFinished()
    {
        //Fill magazine
        Ammo = Data.Ammo;
        IsReloading = false;
        ReloadSound.Play();
        ReloadInHud.fillAmount = 0;
    }
}
