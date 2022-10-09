using Assets.Scripts.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float currentHealth = 100;
    [SerializeField] GameObject DeathEffect;
    [SerializeField] float deathEffectLength = 3;
    public bool DealDamage(float damage)
    {
       
        currentHealth -= damage;
        CheckDeath();
        return currentHealth <= 0;
    }
    public void DealDamage(Collider2D other)
    {
        var damageD = other.gameObject.GetComponent<DamageDealer>();
        if (damageD)
            currentHealth-= damageD.GetDamage();
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            if (DeathEffect)
            {
                var obj = Instantiate(DeathEffect, transform.position - new Vector3(2, 2), Quaternion.identity);
                obj.transform.parent = transform;
                Destroy(obj, deathEffectLength);
            }
            var attacker = GetComponent<Attacker>();
            if(attacker)
            {
                var coinsDisplay = FindObjectOfType<StarDisplay>();
                coinsDisplay.AddStars(attacker.GetCoins());
            }
            Destroy(gameObject);
        }
    }

}
