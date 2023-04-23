using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Target indicator;
    public Animator animator;

    private bool isInfected;

    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;

    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGround;

    //Patrol
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private float walkPointRange;
    [SerializeField] private float timeWalk;

    private float timerWalking;
    private bool walkPointSet;

    [SerializeField] private float sightRange;
    [SerializeField] private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        indicator.SetColor(Color.red);
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInfected)
        {
            walkPointSet = false;
            Chase();
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            RandomPatrol();
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
        }
    }

    void RandomPatrol()
    {
        if (!walkPointSet)
        {
            RandomWalkPoint();
        }

        if (walkPointSet)
        {
            enemy.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (timerWalking > 0f)
        {
            timerWalking -= Time.deltaTime;
        }

        if (distanceToWalkPoint.magnitude < 1f || timerWalking <= 0f)
        {
            walkPointSet = false;
            timerWalking = timeWalk;
        }
    }

    private void RandomWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void Chase()
    {
        enemy.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, walkPointRange);
    }

    void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "NPC") && !isInfected)
        {
            isInfected = true;
            indicator.SetColor(Color.green);
            ScoreTracker.currentScore += 1;
            FindObjectOfType<AudioManager>().Play("Cough");
            Debug.Log("Infected");
        }
    }
}
