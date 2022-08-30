using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Abstracts.Collectable;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Combats;

namespace MyLittleMario.Collectable
{
    public class HealthController : CollectableController
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.HasHitPlayer())
            {
                collision.collider.GetComponent<PlayerHealthController>().HealthIncrease(this);

                KillThisGameObject();
            }
        }
    }

}
