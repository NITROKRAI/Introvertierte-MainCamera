using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 movDir;
    private float speed = 30;
    public GameObject triggerEnemy;
    public float damage;
    private Rigidbody rb;
    public float lifeSpan;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        BulletLifeSpan();
    }
    //void SetDirection(Vector3 dir)
    //{
    //    movDir = dir;
    //}
    private void OnEnable()
    {
        ApplyMovement();
        lifeSpan = 0;
    }
    void ApplyMovement()
    {
       rb.velocity = transform.forward * speed;
    }
    public void BulletLifeSpan()
    {
        lifeSpan += Time.deltaTime;
        if(lifeSpan >= 5)
        {
            lifeSpan = 0;
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player Bullet" && other.tag == "Player")
        {
            
        }
        if(gameObject.tag == "Enemy Bullet" && other.tag == "Enemy")
        {
            
        }
        else if(gameObject.tag == "Enemy Bullet" && other.tag =="Player")
        {
            gameObject.SetActive(false);
        }
        else if(other.tag == "Enemy")
        {   
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Enemy>().health -= damage;
            gameObject.SetActive(false);
        }
        if(gameObject.tag == "Player Bullet" | other.tag == "Enemy Bullet")
        {
            
        }
        else
        {
            gameObject.SetActive(false);
        } 
    }
}
    


