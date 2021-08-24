using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawnPoint;
    [SerializeField] private GameObject Bullet;
    [SerializeField] ParticleSystem PukeEffect;
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Vector3 walkPoint;
    private bool walkPointSet;
    private float walkPointRange;

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;
    private bool isInvincible;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) Attack();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;


        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void Attack()
    {
        transform.LookAt(player);
        GameObject Bullet = ObjectPool.instance.GetPooledObject();

        if (isInvincible)
        {
            return;
        }

        isInvincible = true;

        if (Bullet != null)
        {
            PukeEffect.Play();
            Bullet.tag = "Enemy Bullet";
            Bullet.transform.position = bulletSpawnPoint.transform.position;
            Bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
            Bullet.SetActive(true);
        }

        StartCoroutine(Invinciblity());

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator Invinciblity()
    {
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
