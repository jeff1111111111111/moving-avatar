using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float launchForce = 50f;

    [SerializeField] private float destroyAfterSeconds = 5f;
    [SerializeField] private float damage = 20f;
    private string tagName;
    [SerializeField] private bool TagTog;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * launchForce;  
        if (TagTog == true)
        {
            tagName = "Player";
        }
        else
        {
            tagName = "Enemy";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    private void OnCollisionEnter(Collision other)

    {
        if (other.gameObject.tag == tagName)
        {
            Health _health = other.transform.GetComponent<Health>();
            if (_health == null)
            {
                Debug.Log(">>>> Health script missing from Player/Enemy <<<<");

                return;
            }
            _health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
