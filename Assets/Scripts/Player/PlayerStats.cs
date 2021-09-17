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
    [SerializeField] AudioSource PickUpSound;
    private Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        Data.IsInvincible = false;
        Debug.Log(PlayerPrefs.GetInt("Health"));
        CurrentHealth = GetHealth();
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

    void OnDestroy()
    {
        Debug.Log("Player will be destroyed");
        SetHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            GetHeart();
        }
        else if (other.gameObject.CompareTag("Enemy Bullet") && Data.IsInvincible == false)
        {
            TakeDamage();
        }
        else if (other.gameObject.CompareTag("Trap") && Data.IsInvincible == false)
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
            //Data.Health += 1;
            CurrentHealth += 1;
            PickUpSound.Play();

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
        //Data.Health -= 1;
        CurrentHealth -= 1;
        HurtSound.Play();
    }
    public int GetHealth()
    {
        return PlayerPrefs.GetInt("Health");
    }

    public void SetHealth()
    {
        PlayerPrefs.SetInt("Health", CurrentHealth);
    }
}
