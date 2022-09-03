using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Controllers;
using MyLittleMario.Abstracts.Combats;

namespace MyLittleMario.Combats
{
    public class SpearController : ThrowWeapon 
    {
        protected override void TrowAction()
        {
            if (transform.parent != null && transform.parent.tag == "ThrownWeaponHolder")
            {
                doesDrop = false;
                _rigidbody2D.AddForce(new Vector2(1 * direction, 0.2f) * forcePower);
            }
            else
            {
                doesDrop = true;
                this.gameObject.layer = 11;
                _rigidbody2D.AddForce(Vector2.up * 200);
                StartCoroutine(LayerController(4f));
            }
            
        }

    }

}
