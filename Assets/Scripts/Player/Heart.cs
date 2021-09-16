using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public PlayerStats Stats;
    private int health;

    private void Start()
    {
        Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
    private void Update()
    {
        health = Stats.CurrentHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && health < 6)
        {            
            Destroy(gameObject);
        }
    }
}
