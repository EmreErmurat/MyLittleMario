using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Combats;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Abstracts.Combats;

namespace MyLittleMario.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {

        Damage damage;

        private void Awake()
        {
            damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health _health = collision.ObjectHasHealth();

            if (_health != null)
            {
                _health.TakeHit(damage);
            }
        }




    }
}

