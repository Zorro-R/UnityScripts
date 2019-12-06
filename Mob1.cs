using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private int followRadius = 40;
    [SerializeField] private int unfollowRadius = 50;
    [SerializeField] private GameObject player;
    private Vector3 dirToPlayer;
    private bool hasSpottedPlayer = false;
    private float rangeToPlayer;



    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        // Calculate distance and a direction to the player (In x direction)
        rangeToPlayer = Vector3.Distance(transform.position, player.transform.position);
        dirToPlayer = Vector3.Normalize(new Vector3(player.transform.position.x - transform.position.x, 0, 0));

        // If player is within follow range move towards them (only in x direction)
        if (rangeToPlayer <= followRadius)
        {
            transform.Translate(speed * dirToPlayer * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
