using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health;
    float invincibility;
    bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (invincibility > 0)
        {
            invincibility -= Time.deltaTime;
            isInvincible = true;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("EnemyBullet"))
    //    {
    //        Health = Health - 5;
    //    }
    //
    //}
    //
    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy") && invincibility <= 0)
    //    {
    //        TakeDamage(1);
    //        invincibility = 1f;
    //    }
    //}

    void TakeDamage(float damage)
    {
        Health = Health - damage;
    }
}
