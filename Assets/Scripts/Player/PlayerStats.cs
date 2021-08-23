using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public MobData Data;
    public float CurrentHealth;

    private bool alreadyGetHeart;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            GetHeart();
            Debug.Log("PlayerHeart");
        }

        if (other.gameObject.CompareTag("Enemy Bullet") && Data.IsInvincible == false)
        {
            CurrentHealth -= 1;
            Invincibility();
        }

        if (other.gameObject.CompareTag("Trap") && Data.IsInvincible == false)
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

    public void GetHeart()
    {
        if (alreadyGetHeart)
        {
            return;
        }

        if (CurrentHealth < 6)
        {
            alreadyGetHeart = true;
            CurrentHealth += 1;
            Debug.Log("LifeUp");
            StartCoroutine(AlreadyGetHeart());
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

    IEnumerator AlreadyGetHeart()
    {
        yield return new WaitForSeconds(0.5f);
        alreadyGetHeart = false;
    }
}
