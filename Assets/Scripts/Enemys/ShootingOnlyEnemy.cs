using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingOnlyEnemy : MonoBehaviour
{
    public GameObject Bullet;
    public float ShootPower;
    public GameObject bulletSpawnPoint;
    private Transform player; 

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
        //Vector3 spawnPos;

        transform.LookAt(player);
        GameObject Bullet = ObjectPool.instance.GetPooledObject();

        if (isInvincible)
        {
            return;
        }

        isInvincible = true;

        if (Bullet != null)
        {
            Bullet.tag = "Player Bullet";
            Bullet.transform.position = bulletSpawnPoint.transform.position;
            Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
            Bullet.SetActive(true);
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
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
