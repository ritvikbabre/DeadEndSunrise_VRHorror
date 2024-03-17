using JetBrains.Annotations;
using StarterAssets;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float chaseRange = 10f;
    public float closeRange = 2f;
    public float patrolRadius = 5f;
    public float moveSpeed = 5f;
    public float grabDistance = 1.5f;
    [HideInInspector]public Transform player;
    public Transform grabPoint;
    public LayerMask playerLayer;
    public Animator animator;

    private NavMeshAgent navMeshAgent;
    private Vector3 lastKnownPlayerPosition;
    [SerializeField] private bool isChasing = false;
    [SerializeField] private bool isPatrolling = false;
    private Vector3 patrolDestination;

    //grabbing stuff
    



    // Adjust these variables according to your needs
   
    public float reductionTime = 5f;      // Reduce patrol radius every X seconds
    [SerializeField]private float patrolReductionAmount = 10f;
    [SerializeField]private float minPatrolDistance;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        Patrol();
        StartCoroutine(ReducePatrolRadius());

    }

    void Update()
    {
        // Check if player is within chase range
        if (Vector3.Distance(transform.position, player.position) <= chaseRange)
        {
            // Check if player is in line of sight
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit, Mathf.Infinity, playerLayer))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    lastKnownPlayerPosition = player.position;
                    StopPatrol();
                    isChasing = true;
                }
                else
                {
                    isChasing = false;
                }
            }
        }
        else
        {
            isChasing = false;
        }

            Debug.Log(navMeshAgent.remainingDistance);
        if (isChasing)
        {
            // Move towards the player
            // navMeshAgent.SetDestination(player.position);
            //Debug.Log("Player pos " + player.position);
            NavMeshHit navMeshHit;

            if (NavMesh.SamplePosition(player.position, out navMeshHit, patrolRadius, NavMesh.AllAreas))
            {
                Vector3 playerpos = navMeshHit.position;
                navMeshAgent.SetDestination(playerpos);
                Debug.Log("patrolDestination : " + patrolDestination);
            }
            animator.SetBool("isRunning", true);

  //          Debug.Log("chasng");
            // Check if player is within close range
            if (Vector3.Distance(transform.position, player.position) <= closeRange)
            {
                // Attack (grab) the player
                GrabPlayer();
            }
        }
        else if (isPatrolling)
        {
            // Check if enemy has reached patrol destination
            if (Vector3.Distance(transform.position, patrolDestination) <= 3f)
            {
                Patrol();
            }
        }

        // Check if player is out of chase range or line of sight
        if (!isChasing && !isPatrolling)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > chaseRange)
            {
                ReturnToLastKnownPlayerPosition();
            }
            else
            {
                RaycastHit hit;
                if (!Physics.Raycast(transform.position, player.position - transform.position, out hit, distanceToPlayer, playerLayer))
                {
                    ReturnToLastKnownPlayerPosition();
                }
            }
        }
    }

    void Patrol()
    {
        isPatrolling = true;
        animator.SetBool("isRunning", true);
        Vector2 randomDirection = Random.insideUnitCircle * patrolRadius;
        Vector3 randomPoint = player.position + new Vector3(randomDirection.x, 0, randomDirection.y);
        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(randomPoint, out navMeshHit, patrolRadius, NavMesh.AllAreas))
        {
            patrolDestination = navMeshHit.position;
            navMeshAgent.SetDestination(patrolDestination);
            Debug.Log("patrolDestination : " + patrolDestination);
        }
    }

    void StopPatrol()
    {
        isPatrolling = false;
        animator.SetBool("isRunning", false);
        navMeshAgent.ResetPath();
    }

    void ReturnToLastKnownPlayerPosition()
    {

            animator.SetBool("isRunning", true);
            navMeshAgent.SetDestination(lastKnownPlayerPosition);
        if (Vector3.Distance(lastKnownPlayerPosition, transform.position) < 2f) Patrol();    
    }

    void GrabPlayer()
    {
        // Check if grab point is close enough to player
        if (Vector3.Distance(grabPoint.position, player.position) <= grabDistance)
        {
            Debug.Log("Enemy grabs the player!");
            player.position = grabPoint.position;
            player.gameObject.GetComponent<FirstPersonController>().enabled = false;
            animator.SetTrigger("GrabPlayer");


        }
        

    }
    public void GameOver()
    {
        GameManager.Instance.GAMEOVER();
        this.enabled = false;
    }

    IEnumerator ReducePatrolRadius()
    {
        while (true)
        {
            yield return new WaitForSeconds(reductionTime);
            
                patrolRadius -= patrolReductionAmount;
                if (patrolRadius <= minPatrolDistance) patrolRadius = minPatrolDistance;
            
        }
    }
    void OnDrawGizmosSelected()
    {
        // Visualize the chase range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        // Visualize the close range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeRange);

        // Visualize the patrol radius
        if (player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(player.position, patrolRadius);
        }

        // Visualize the grab range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(grabPoint.position, grabDistance);
    }
}
