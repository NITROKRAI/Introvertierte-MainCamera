using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOnlyEnemy : MonoBehaviour
{
    public GameObject Bullet;
    public float ShootPower;
    public GameObject bulletSpawnPoint;
    private Transform player;
    public GameObject[] bulletSpawnPoints = new GameObject[0];
    private int shotTimes;

    public Transform PlayerCheckPos;
    public float PlayerCheckRadios;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(PlayerCheckPos.position, PlayerCheckRadios, LayerMask.GetMask("Player")))
        {
            Attack();
        }
    }

    public void Attack()
    {
        transform.LookAt(player);

        if (isInvincible)
        {
            return;
        }

        isInvincible = true;

        if (shotTimes <= 4)
        {
            if (Bullet != null)
            {
                GameObject Bullet = ObjectPool.instance.GetPooledObject();
                Bullet.tag = "Enemy Bullet";
                Bullet.transform.position = bulletSpawnPoint.transform.position;
                Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
                Bullet.SetActive(true);

                shotTimes += 1;
            }
        }

        if (shotTimes == 5)
        {
            for (int b = 0; b < bulletSpawnPoints.Length; b++)
            {

                if (Bullet != null)
                {
                    GameObject Bullet = ObjectPool.instance.GetPooledObject();
                    Bullet.tag = "Enemy Bullet";
                    Bullet.transform.position = bulletSpawnPoints[b].transform.position;
                    Bullet.transform.rotation = bulletSpawnPoints[b].transform.rotation;
                    Bullet.SetActive(true);

                    shotTimes = 0;
                }
            }
        }

        StartCoroutine(Invinciblity());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(PlayerCheckPos.position, PlayerCheckRadios);
    }

    IEnumerator Invinciblity()
    {
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
    }
}
