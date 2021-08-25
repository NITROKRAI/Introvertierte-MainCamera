using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        BulletLifeSpan();
    }
    void FixedUpdate()
    {
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
    }
    
}




