using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private MovementInfo movementInfo;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Chase (Transform target) // make the enemy calculate and path towards a given target and start running
    {
        agent.speed = movementInfo.MovementSpeed; // the movement speed of the enemy may change so important to set before chasing every time
        agent.SetDestination(target.position);
        agent.isStopped = false;
    }

    public void StopChasing () // stop the enemy from moving
    {
        agent.isStopped = true;
    }
}
