using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemy;

    public void Update()
    {
        enemy.SetDestination(player.position);



    }




}
