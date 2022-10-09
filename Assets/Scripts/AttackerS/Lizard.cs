using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherCollider.gameObject);
        }
    }
}
