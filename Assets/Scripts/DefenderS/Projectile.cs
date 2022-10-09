using Assets.Scripts.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : DamageDealer
{
    [SerializeField] float lifeTime=20;
    [SerializeField] float speed=1;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Health>().DealDamage(damageDealt);
        Destroy(gameObject);
    }
}
