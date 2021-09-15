using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingIdol : MonoBehaviour
{
    public GameObject BulletSpawnPoint;
    public GameObject Bullet;
    public bool isActivated;
    public bool CanShoot;
    public float FireRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated && CanShoot)
        {
            GameObject Bullet = ObjectPool.instance.GetPooledObject();
            Bullet.tag = "Enemy Bullet";
            Bullet.transform.position = BulletSpawnPoint.transform.position;
            Bullet.transform.rotation = BulletSpawnPoint.transform.rotation;
            Bullet.SetActive(true);
            CanShoot = false;
            Invoke("ResetShot", FireRate);
        }
    }
    private void ResetShot()
    {
        CanShoot = true;
    }
}
