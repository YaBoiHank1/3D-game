using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float chaseRange;
    public float searchRange;
    public float wanderRadius;
    public float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private float speed;
    public bool lightHit;
    Vector3 home;
    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        speed = GetComponent<NavMeshAgent>().speed;
    }

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!lightHit)
        {
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > chaseRange && distance < searchRange)
            {
                StartCoroutine(Search());
                GetComponent<NavMeshAgent>().speed = 3f;
                Debug.Log("Inside Search Range");
            }
            if (distance < chaseRange)
            {
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                GetComponent<NavMeshAgent>().speed = 6f;
                Debug.Log("Inside Chase Range");
            }
            else
            {
                //GetComponent<NavMeshAgent>().SetDestination(home);
                //Debug.Log("Returning to Wandering");
                GetComponent<NavMeshAgent>().speed = 2f;
                return;
            }
        }
        else
        {
            return;
        }
        
        
    }

    public void Chase()
    {
        lightHit = true;
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        GetComponent<NavMeshAgent>().speed = 6f;
        Debug.Log("Hit by Flashlight");
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navMesh;
        NavMesh.SamplePosition(randDirection, out navMesh, dist, layermask);
        return navMesh.position;
    }

    private IEnumerator Search()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < searchRange && distance > chaseRange)
        {
            Vector3 newPos = RandomNavSphere(player.transform.position, searchRange, -1);
            agent.SetDestination(newPos);
            yield return new WaitForSeconds(5);
        }
    }
}
