using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GhoulController : MonoBehaviour
{
    
    public enum AISTATE { PATROL, CHASE, ATTACK };

    public Transform player;
    public NavMeshAgent enemy;
    public AISTATE enemyState = AISTATE.PATROL; // Current state of the Ghoul
    float distanceOffset = 2.0f; // Distance offset for various calculations
    float chaseDistance = 10.0f; // Distance at which the Ghoul will start chasing the player

    public List<Transform> waypoints = new List<Transform>();
    Transform currentWaypoint; // Current waypoint the Ghoul is moving towards

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

        // Start the coroutine corresponding to the new state
        switch (enemyState)
        {
            case AISTATE.PATROL:
                StartCoroutine(PatrolState());
                break;
            case AISTATE.CHASE:
                StartCoroutine(ChaseState());
                break;
            case AISTATE.ATTACK:
                StartCoroutine(AttackState());
                break;
        }
    }

    public IEnumerator ChaseState()
    {
        // Set the destination of the Ghoul to the player's position
        enemy.SetDestination(player.position);
        while (enemyState == AISTATE.CHASE)
        {
            // If the player is within the distance offset, switch to Attack state
            if (Vector3.Distance(transform.position, player.position) < distanceOffset)
            {
                ChangeState(AISTATE.ATTACK);
                yield break;
            }
            // If the player is too far away, switch back to Patrol state
            if (Vector3.Distance(transform.position, player.position) > chaseDistance)
            {
                ChangeState(AISTATE.PATROL);
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Coroutine for the Attack state
    public IEnumerator AttackState()
    {
        while (enemyState == AISTATE.ATTACK)
        {
            // If the player moves out of the distance offset, switch back to Chase state
            if (Vector3.Distance(transform.position, player.position) > distanceOffset)
            {
                ChangeState(AISTATE.CHASE);
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Coroutine for the Patrol state
    public IEnumerator PatrolState()
    {
        while (enemyState == AISTATE.PATROL)
        {
            // Set the destination of the Ghoul to the current waypoint's position
            enemy.SetDestination(currentWaypoint.position);
            // If the Ghoul reaches the current waypoint, select a new random waypoint
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceOffset)
            {
                currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
                enemy.SetDestination(currentWaypoint.position);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.CHASE);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.PATROL);
        }
    }
}

