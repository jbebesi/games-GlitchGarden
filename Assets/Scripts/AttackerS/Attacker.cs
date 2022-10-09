using Assets.Scripts.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 0f;
    [SerializeField] float damage = 0f;
    [SerializeField] int coins = 0;
    GameObject target;

    void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (!target)
        {
            GetComponent<Animator>()?.SetBool("IsAttacking", false);
            transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        }
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject defender)
    {
        GetComponent<Animator>()?.SetBool("IsAttacking", true);
        target = defender;
    }
    public void StrikeCurrentTarget()
    {
        if (!target)
        {
            Debug.Log("No more target!");
            GetComponent<Animator>()?.SetBool("IsAttacking", false);
            return;
        }
        var health = target.GetComponent<Health>();

        if (!health || health.DealDamage(damage))
        {
            GetComponent<Animator>()?.SetBool("IsAttacking", false);
        }
    }

    public int GetCoins() => coins;

}
