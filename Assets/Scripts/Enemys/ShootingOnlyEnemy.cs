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
    float randomSpreadY;
    float minSpread = 0.1f;
    float maxSpread = 0.3f;

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
        //GameObject Bullet = ObjectPool.instance.GetPooledObject();

        if (isInvincible)
        {
            return;
        }

        isInvincible = true;

        
        for (int i = 0; i < bulletSpawnPoints.Length; i++)
        {
           
            if (Bullet != null)
            {
                //Debug.Log("dick");
                GameObject Bullet = ObjectPool.instance.GetPooledObject();
                //randomSpreadY += Random.Range(maxSpread, maxSpread);
                Bullet.tag = "Enemy Bullet";
                //DamageReference = Bullet.GetComponent<Bullet>().damage;
                Bullet.transform.position = bulletSpawnPoints[i].transform.position;
                Bullet.transform.rotation = bulletSpawnPoints[i].transform.rotation;
                Bullet.SetActive(true);

            }
        }

        //if (Bullet != null)
        //{
        //    Bullet.tag = "Enemy Bullet";
        //    Bullet.transform.position = bulletSpawnPoint.transform.position;
        //    Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        //    Bullet.SetActive(true);
        //}

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
