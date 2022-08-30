using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Abstracts.Collectable
{
    public abstract class CollectableController : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody2D;
        [SerializeField] protected int score;
        [SerializeField] protected float jumpForce = 200f;

        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected void OnEnable()
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }

        protected abstract void OnCollisionEnter2D(Collision2D collision);

        protected void KillThisGameObject()
        {
            Destroy(this.gameObject);
        }



    }
}
