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

    public AIState currentState = AIState.Idle;

    private Vector3 home;

    private Vector3 target;

    public float chargeSpeed = 2.0f;

    public float returnSpeed = 1.0f;
    void Start()
    {
        home = transform.position;
        agent = GetComponent<NavMeshAgent>();
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
                Return();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Attack");
            target = other.transform.position;
            currentState = AIState.Attack;
        }
    }

    private void ChargeAtPlayer()
    {
        Debug.Log("attacking");
        //agent.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * chargeSpeed);
        agent.destination = target;
        
    }

    private void Return()
    {
        transform.position = Vector3.MoveTowards(transform.position, home, Time.deltaTime * returnSpeed);
    }

    private void Patrol()
    {

    }
}
