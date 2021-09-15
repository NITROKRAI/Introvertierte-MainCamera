using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private GameObject triggerEnemy;
    public float Damage;
    private Rigidbody rb;
    public float LifeSpan;
    public GameObject ParticlePrefab;
    public GameObject RaycastPos;
    Vector3 prevPos;
    public LayerMask LayerMask;
    public ParticleSystem BulletHole;
    string otherTag;
    public Material PlayerBulletMaterial;
    public Material EnemyBulletMaterial;
    Renderer rend;
    void Start()
    {
        prevPos = transform.position;
        rend = gameObject.GetComponent<Renderer>();
        ApplyBulletSettings();
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
        ApplyBulletSettings();
    }
    void ApplyBulletSettings()
    {
        if (gameObject.CompareTag("Player Bullet"))
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            rend.material = PlayerBulletMaterial;
            //rend.material.color = Color.yellow;
        }
        else if (gameObject.CompareTag("Enemy Bullet"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rend.material = EnemyBulletMaterial;
            //rend.material.color = Color.red;
        }
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
                    triggerEnemy = other.gameObject;
                    triggerEnemy.GetComponent<Enemy>().health -= Damage;
                    triggerEnemy.GetComponent<Enemy>().MakeDamageSound();
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




