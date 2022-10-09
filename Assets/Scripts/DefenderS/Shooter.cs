using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{

    [SerializeField] GameObject shoot;
    [SerializeField] GameObject gunPosition;
    [SerializeField] float timeBetweenShots = 2;
    
    float waitForShoot;
    AttackerSpawner spawner;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        waitForShoot = timeBetweenShots;
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(var sp in spawners)
        {
            if(Mathf.Abs(gameObject.transform.position.y -sp.transform.position.y)<0.4)
            {
                spawner = sp;
                break;
            }
        }
    }

    void Update()
    {
        waitForShoot -= Time.deltaTime;
        if (IsAttackerInLane())
        {
            animator.SetBool("AttackerInLine", true);
        }
        else
        {
            animator.SetBool("AttackerInLine", false);
        }
    }

    bool IsAttackerInLane() => spawner?.GetComponentsInChildren<Attacker>().Length > 0;

    public void ShotOnce(GameObject ammo)
    {
        if (waitForShoot < 0)
        {
            Instantiate(ammo, gunPosition.transform.position, transform.rotation).transform.parent = transform;
            waitForShoot = timeBetweenShots;
        }
    }
}
