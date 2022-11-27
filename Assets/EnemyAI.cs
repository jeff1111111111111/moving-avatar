using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float EnemyRange = 20f;

    private float distanceBetweenTarget;

    private NavMeshAgent navMeshAgent;

    [SerializeField] private Transform[] projectileSpawnPoint;

    [SerializeField] private GameObject projectilePrejab;

    private float countdownBetweenfire = 0f;

    [SerializeField] private float FireRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { return; }
        distanceBetweenTarget = Vector3.Distance(target.position, transform.position);

        if (distanceBetweenTarget <= EnemyRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
        if (countdownBetweenfire <= 0f)
        {
            foreach (Transform SpawnPoints in projectileSpawnPoint)
            {
                Instantiate(projectilePrejab, SpawnPoints.position, transform.rotation);
            }
            countdownBetweenfire = 1f / FireRate;
        }
        countdownBetweenfire -= Time.deltaTime;
    }
}
