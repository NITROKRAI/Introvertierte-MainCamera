using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public float health;
    void Start()
    {
    
    }

    
    void Update()
    {
        Die();
    }
    public void Die()
    {
        if(health <= 0f)
        {
            Destroy(this.gameObject);
        }
       
    }
}

