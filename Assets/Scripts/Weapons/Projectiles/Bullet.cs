using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public GameObject TriggerEnemy;
    public float Damage;
    private Rigidbody rb;
    public float LifeSpan;
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
        if (Physics.Raycast(transform.position, transform.forward, out hitI,0.6f, LayerMask))
        {
            if (hitI.collider.CompareTag("World"))
            {
                Instantiate(BulletHole, hitI.point, Quaternion.LookRotation(hitI.normal));
                gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        ApplyMovement();
        LifeSpan = 0;
    }
    void ApplyMovement()
    {
        rb.velocity = transform.forward * Speed;
    }
    public void BulletLifeSpan()
    {
        LifeSpan += Time.deltaTime;
        if (LifeSpan >= 5)
        {
            LifeSpan = 0;
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
                    TriggerEnemy = other.gameObject;
                    TriggerEnemy.GetComponent<Enemy>().Health -= Damage;
                    TriggerEnemy.GetComponent<Enemy>().Hurt = true;
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




