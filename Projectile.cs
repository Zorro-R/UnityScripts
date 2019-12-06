using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float BulletSpeed = 20f;
    public int BulletDamage = 20;
    public Rigidbody2D rb;
    public GameObject ImpactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy1 enemy1 = hitInfo.GetComponent<Enemy1>();

        // If an enemy is hit
        if (enemy1 != null)
        {
            enemy1.TakeDamage(BulletDamage);
        }


        Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
