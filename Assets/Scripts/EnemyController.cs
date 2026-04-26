using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum AIState
    {
        Idle,
        Attack,
        Retreat
    }

    NavMeshAgent agent;

    public Transform[] PatrolSpots;

    public int patrolIndex = 0;

    public AIState currentState = AIState.Idle;

    private Vector3 home;

    private Vector3 target;

    public float chargeSpeed = 8.0f;

    public float returnSpeed = 3.5f;
    private float waitTimer;

    private Animator _animator;

    void Start()
    {
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case AIState.Idle:
                Patrol();
                break;
            case AIState.Attack:
                ChargeAtPlayer();
                break;
            case AIState.Retreat:
                break;
        }
    }

    private void LateUpdate()
    {
        agent.transform.LookAt(agent.destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Attack");
            target = other.transform.position;
            currentState = AIState.Attack;
            GetComponent<AudioSource>().Play();
            _animator.SetBool("Attack", true);
        }
    }

    private void ChargeAtPlayer()
    {
        Debug.Log("attacking");
        agent.speed = chargeSpeed;
        agent.SetDestination(target);
        waitTimer += Time.deltaTime;
        if (waitTimer >= 1f)
        {
            agent.speed = returnSpeed;
            waitTimer = 0f;
            currentState = AIState.Idle;
            _animator.SetBool("Attack", false);
        }
        
    }

    private void Patrol()
    {
        if (agent.remainingDistance < 0.1f)
        {
            patrolIndex = (patrolIndex + 1) % PatrolSpots.Length;
            agent.SetDestination(PatrolSpots[patrolIndex].position);
        }
            
        
    }
}
