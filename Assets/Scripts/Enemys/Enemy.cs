using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float health;
    public bool Hurt;
    [Range(0, 1)] public float HealthDropChance;
    public GameObject Heart;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip enemyDamageSound;

    void Update()
    {
        Die();
    }
    public void MakeDamageSound()
    {
        audioSource.PlayOneShot(enemyDamageSound);
        Hurt = false;
    }

    public void Die()
    {
        if(health <= 0f)
        {
            if (UnityEngine.Random.value < HealthDropChance)
            { Instantiate(Heart, transform.position, Quaternion.identity); }
            Destroy(this.gameObject);
        }
    }
}