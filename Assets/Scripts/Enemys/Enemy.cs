using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float Health;
    public bool Hurt;
    [Range(0, 1)] public float HealthDropChance;
    public GameObject Heart;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip enemyDamageSound;

    void Update()
    {
        if (Hurt)
        {
            MakeDamageSound();
        }

        Die();
    }
    private void MakeDamageSound()
    {
        audioSource.PlayOneShot(enemyDamageSound);
        Hurt = false;
    }

    public void Die()
    {
        if(Health <= 0f)
        {
            if (UnityEngine.Random.value < HealthDropChance)
            { Instantiate(Heart, transform.position, Quaternion.identity); }
            Destroy(this.gameObject);
        }
    }
}