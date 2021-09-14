using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public MobData Data;
    public int CurrentHealth;    
    private bool alreadyGetHeart;
    public float ElapsedTime;    
    [SerializeField] AudioSource HurtSound;
    private Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        Data.IsInvincible = false;
        CurrentHealth = Data.Health;
        r = gameObject.GetComponent<Renderer>();
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
        else if(other.gameObject.CompareTag("Enemy Bullet") && Data.IsInvincible == false)
        {
            TakeDamage();
        }
        else if(other.gameObject.CompareTag("Trap") && Data.IsInvincible == false)
        {
            TakeDamage();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Data.IsInvincible == false)
        {
            TakeDamage();
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
        ElapsedTime = 0;
        Data.IsInvincible = true;
        Invoke("ResetInvincibility", Data.InvincibilityTimer);
        StartCoroutine(Flash());
    } 
    void ResetInvincibility()
    {
        Data.IsInvincible = false;
    }
    IEnumerator Flash()
    {
        for (int i = 0; i < 2; i++)
        {
            //r.enabled = false;
            r.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            //r.enabled = true;
            r.material.color = Color.white;
            yield return new WaitForSeconds(.1f);
            
        }
    }
    IEnumerator AlreadyGetHeart()
    {
        yield return new WaitForSeconds(0.5f);
        alreadyGetHeart = false;
    }
    public void TakeDamage()
    {
        Invincibility();
        CurrentHealth -= 1;
        HurtSound.Play();
    }
}
