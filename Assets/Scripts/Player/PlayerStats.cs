using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public MobData Data;
    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Data.IsInvincible = false;
        CurrentHealth = Data.Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth == 0)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet") && Data.IsInvincible == false)
        {
            CurrentHealth -= 1;
            Invincibility();
        }
        
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Data.IsInvincible == false)
        {
            CurrentHealth -= 1;
            Invincibility();
        }
    }
    void Invincibility()
    {
        Data.IsInvincible = true;
        Invoke("ResetInvincibility", Data.InvincibilityTimer);
    }
    void ResetInvincibility()
    {
        Data.IsInvincible = false;
    }
}
