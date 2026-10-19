using UnityEngine;
using UnityEngine.AI;

public class AnimalWander : MonoBehaviour
{
    public float wanderRadius = 6f;
    public float waitTime = 3f;

    private NavMeshAgent agent;
    private Vector3 center;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        center = transform.position;
        timer = waitTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * wanderRadius;
            randomPoint.y = center.y;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 2f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
            timer = 0f;
        }
    }
}