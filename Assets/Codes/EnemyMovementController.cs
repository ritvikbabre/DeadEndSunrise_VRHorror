using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_StateController : MonoBehaviour
{
    public enum AISTATE { PATROL, CHASE, ATTACK };

    public Transform player;
    public NavMeshAgent enemy;
    public AISTATE enemyState = AISTATE.PATROL;
    float distanceOffset = 2.0f;
    float chaseDistance = 10.0f;

    public List<Transform> waypoints = new List<Transform>();
    Transform currentWaypoint;

    public Animator enemyAnimator;

    public void Start()
    {
        currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
        ChangeState(AISTATE.PATROL);
    }

    public void ChangeState(AISTATE newState)
    {
        // Stop all coroutines to ensure a clean state change
        StopAllCoroutines();
        enemyState = newState;

        // Set trigger in Animator
        switch (enemyState)
        {
            case AISTATE.PATROL:
                enemyAnimator.SetBool("IsPatrolling", true);
                StartCoroutine(PatrolState());
                break;
            case AISTATE.CHASE:
                enemyAnimator.SetBool("IsChasing", true);
                StartCoroutine(ChaseState());
                break;
            case AISTATE.ATTACK:
                enemyAnimator.SetBool("IsAttacking", true);
                StartCoroutine(AttackState());
                break;
        }
    }

    public IEnumerator ChaseState()
    {
        print("Chasing");
        while (enemyState == AISTATE.CHASE)
        {
            enemyAnimator.SetBool("IsPatrolling", false);

            enemy.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) < distanceOffset)
            {
                ChangeState(AISTATE.ATTACK);
                yield break;
            }

            if (Vector3.Distance(transform.position, player.position) > chaseDistance)
            {
                ChangeState(AISTATE.PATROL);
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator AttackState()
    {
        print("Attacking");
        while (enemyState == AISTATE.ATTACK)
        {
            enemyAnimator.SetBool("IsChasing", false);

            if (Vector3.Distance(transform.position, player.position) > distanceOffset)
            {
                ChangeState(AISTATE.CHASE);
                enemy.stoppingDistance = 2.0f;
                enemy.SetDestination(player.position);
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator PatrolState()
    {
        print("Patrolling");
        while (enemyState == AISTATE.PATROL)
        {
            enemyAnimator.SetBool("IsAttacking", false);
            enemyAnimator.SetBool("IsChasing", false);

            enemy.SetDestination(currentWaypoint.position);

            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceOffset)
            {
                currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
                enemy.SetDestination(currentWaypoint.position);
            }

            if (Vector3.Distance(transform.position, player.position) < chaseDistance)
            {
                ChangeState(AISTATE.CHASE);
                yield break;
            }

            yield return null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.CHASE);
            print("Player Detected");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.PATROL);
            print("Player is Lost");
        }
    }
}
