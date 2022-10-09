using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GraveStone")
        {
            var anim = GetComponent<Animator>();
            anim.SetBool("Jump", true);
        }
        else if(other.gameObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other.gameObject);
        }
    }
}
