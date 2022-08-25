using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Combats;
using MyLittleMario.ExtensionMethods;

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
            HealthConrtoller healthConrtoller = collision.ObjectHasHealth();

            if (healthConrtoller != null)
            {
                healthConrtoller.TakeHit(damage);
            }
        }




    }
}

