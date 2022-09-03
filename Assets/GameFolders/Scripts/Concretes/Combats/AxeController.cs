using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Abstracts.Combats;

public class AxeController : ThrowWeapon
{

    protected override void TrowAction()
    {
        if (transform.parent != null && transform.parent.tag == "ThrownWeaponHolder")
        {
            _rigidbody2D.AddForce(new Vector2(1 * direction, 0.2f) * forcePower);
            _rigidbody2D.AddTorque(70 * -direction);
            
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
