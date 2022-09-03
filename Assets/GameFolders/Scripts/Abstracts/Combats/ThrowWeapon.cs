using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Combats;
using MyLittleMario.Controllers;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Abstracts.Combats
{
    public abstract class ThrowWeapon : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody2D;
        protected Damage damage;


        protected float forcePower = 800;
        protected float negativeForce = 20;
        protected float direction;

        protected bool doesDrop;

        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            damage = GetComponent<Damage>();

            PlayerController player = GameManager.Instance.PlayerObject.GetComponent<PlayerController>();

            if (player != null)
            {
                direction = player.PlayerDirection;
                transform.localScale = new Vector3(transform.localScale.x * direction, 1, 1);
            }
        }

        protected void OnEnable()
        {

            TrowAction();

            if (!doesDrop)
            {
                StartCoroutine(LayerController(.5f));
            }
            

        }

        protected void FixedUpdate()
        {
            _rigidbody2D.AddRelativeForce(-_rigidbody2D.velocity * negativeForce * Time.deltaTime);


        }

        protected IEnumerator LayerController(float value)
        {
            yield return new WaitForSeconds(value);
            this.gameObject.layer = 10;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.ObjectHasHealth())
            {
                if (collision.HasHitEnemy())
                {
                    if (collision.relativeVelocity.magnitude > 10f)
                    {
                        damage.HitTarget(collision.ObjectHasHealth());
                    }

                }

            }

        }

        protected abstract void TrowAction();
    }

}
