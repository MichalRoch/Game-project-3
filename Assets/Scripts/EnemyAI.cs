using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float chaseRange = 10f;
    public float lostSightTime = 3f;

    private NavMeshAgent agent;
    private Transform player;
    private int currentPatrolIndex;
    private float timeSinceLastSeenPlayer;
    private enum State { Patrol, Chase }
    private State currentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentPatrolIndex = 0;
        currentState = State.Patrol;
        GoToNextPatrolPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)      // W zale¿noœci od tego czy gracz jest w zasiêgu czy nie 
        {
            case State.Patrol:
                Patrol();                   // Patroluje jak gracz poza zasiêgiem
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = State.Chase;
                }
                break;

            case State.Chase:           // Goni gracza jak w zasiêgu
                ChasePlayer();
                if (distanceToPlayer > chaseRange)
                {
                    timeSinceLastSeenPlayer += Time.deltaTime;
                    if (timeSinceLastSeenPlayer >= lostSightTime)
                    {
                        currentState = State.Patrol;
                        GoToNextPatrolPoint();
                    }
                }
                else
                {
                    timeSinceLastSeenPlayer = 0;
                }
                break;
        }
    }

    void Patrol()           
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()              // Porusza siê po wyznaczonych punktach
    {
        if (patrolPoints.Length == 0) return;
        agent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void ChasePlayer()
    {
        agent.destination = player.position;
    }
}
