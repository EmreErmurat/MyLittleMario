using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Abstracts.Collectable;
using MyLittleMario.ExtensionMethods;


namespace MyLittleMario.Controllers
{
    public class GemController : CollectableController
    {
        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.HasHitPlayer())
            {
                GameManager.Instance.IncreaseScore(score);
                Destroy(this.gameObject);

            }
        }

        

    }

}
