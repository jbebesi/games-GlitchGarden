using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BaseClasses
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] protected float damageDealt = 1000;

        public float GetDamage() => damageDealt;

    }
}
