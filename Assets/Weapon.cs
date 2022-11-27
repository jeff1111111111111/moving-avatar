using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform[] projectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Transform SpawnPoints in projectileSpawnPoint )
            {
                Instantiate(projectilePrefab, SpawnPoints.position, transform.rotation);
            }
        }
    }
}
