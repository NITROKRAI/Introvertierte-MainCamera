using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 movDir;
    private float speed = 10;
    public GameObject triggerEnemy;
    public float damage;
    public float lifeSpan;
    void Start()
    {

    }

    void Update()
    {
        ApplyMovement();
        BulletLifeSpan();
    }
    //void SetDirection(Vector3 dir)
    //{
    //    movDir = dir;
    //}
    
    void ApplyMovement()
    {
        //transform.Translate(movDir * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void BulletLifeSpan()
    {
        lifeSpan += 1 * Time.deltaTime;
        if(lifeSpan >= 5)
        {
            gameObject.SetActive(false);
            lifeSpan = 0;
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
            //gameObject.SetActive(false);
        }
    }
}
