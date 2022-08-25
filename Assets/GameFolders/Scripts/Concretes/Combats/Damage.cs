using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;

        public int HitDamage => damage;

        public void HitTarget(HealthConrtoller healthConrtoller)
        {
            healthConrtoller.TakeHit(this);
        }
    }
}

