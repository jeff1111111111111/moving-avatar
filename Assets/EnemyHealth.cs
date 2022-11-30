using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth = 20;
    public static bool isEnemyDead = false;
    private int range = 30;
    private bool canShootAtPlayer = true;
    public AudioSource enemyFire;
    public GameObject player;
    private int damage = 10;
    private void Update()
    {

        if (currentHealth > 0 && isEnemyDead == false)
        {

            ShootAtPlayer();

        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0 && isEnemyDead == false)
        {
            gameObject.GetComponent<Animator>().Play("Dying");

            isEnemyDead = true;
        }
    }


    void ShootAtPlayer()
    {

        Ray rayFrom = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(rayFrom, out hit, range))
        {

            if (hit.collider.CompareTag("Player"))
            {

                if (canShootAtPlayer)
                {

                    StartCoroutine(FireGun());

                }

            }

        }

    }

    IEnumerator FireGun()
    {

        canShootAtPlayer = false;

        gameObject.GetComponent<Animator>().Play("Shoot");

        enemyFire.Play();

        //player.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);

        yield return new WaitForSeconds(1.2f);

        canShootAtPlayer = true;

    }

}