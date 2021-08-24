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
    public float test;
    public GameObject ParticlePrefab;
    public GameObject RaycastPos;
    Vector3 prevPos;
    public LayerMask LayerMask;
    public ParticleSystem BulletHole;
    string otherTag;
    void Start()
    {
        prevPos = transform.position;
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //if (Physics.Raycast(prevPos, (transform.position - prevPos).normalized,(transform.position - prevPos).magnitude));
        //{
            
        //}
        //Ray ray;
        //prevPos = transform.position;
        //RaycastHit hit;
        //ray = Physics.Raycast(new Ray(prevPos, (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude);
        BulletLifeSpan();
    }
    void FixedUpdate()
    {
        Ray ray;
        prevPos = transform.position;
        RaycastHit hitI;
        if (Physics.Raycast(transform.position, transform.forward, out hitI,1f, LayerMask))
        {
            if (hitI.collider.CompareTag("World"))
            {
                Instantiate(BulletHole, hitI.point, Quaternion.LookRotation(hitI.normal));
                Debug.Log("raycasthit");
            }
        }
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
        if (lifeSpan >= 5)
        {
            lifeSpan = 0;
            gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        otherTag = other.gameObject.tag;
        if (gameObject.tag == "Player Bullet")
        {
            switch (otherTag)
            {
                case "Enemy":
                    triggerEnemy = other.gameObject;
                    triggerEnemy.GetComponent<Enemy>().health -= damage;
                    gameObject.SetActive(false);
                    break;
                case "World":
                    gameObject.SetActive(false);
                    break;
                default:

                    break;
            }
        }
        //RaycastHit hitI;
        //if (Physics.Raycast(RaycastPos.transform.position, transform.forward, out hitI, LayerMask))
        //{
        //    if (hitI.collider.CompareTag("World"))
        //    {
        //        Instantiate(BulletHole, hitI.point, Quaternion.LookRotation(hitI.normal));
        //        Debug.Log("raycasthit");
        //    }

        //}
        //if (gameObject.tag == "Player Bullet")
        //{
        //    if (other.tag == "Enemy")
        //    {
        //        triggerEnemy = other.gameObject;
        //        triggerEnemy.GetComponent<Enemy>().health -= damage;
        //        gameObject.SetActive(false);
        //    }
        //    if (other.tag == "World")
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
        
    }
    //public void OnColliderEnter(Collider other)
    //{
    //Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
    //if(gameObject.tag == "Wall")
    //{
    //    Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity);
    //}
    //if(gameObject.tag == "Player Bullet" && other.tag == "Player")
    //{

    //}
    //if(gameObject.tag == "Enemy Bullet" && other.tag == "Enemy")
    //{

    //}
    //else if(gameObject.tag == "Enemy Bullet" && other.tag =="Player")
    //{
    //    gameObject.SetActive(false);
    //}
    //else if(other.tag == "Enemy")
    //{   
    //    triggerEnemy = other.gameObject;
    //    triggerEnemy.GetComponent<Enemy>().health -= damage;
    //    gameObject.SetActive(false);
    //}
    //if(gameObject.tag == "Player Bullet" | other.tag == "Enemy Bullet")
    //{

    //}
    //else
    //{
    //    gameObject.SetActive(false);
    //} 
    //}
}




