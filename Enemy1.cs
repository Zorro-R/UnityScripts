using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int Health = 100;
    public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
