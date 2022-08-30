using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.ExtensionMethods;


namespace MyLittleMario.Controllers
{
    public class GemController : MonoBehaviour
    {
        Rigidbody2D _rigidbody2D;

        [SerializeField] int score = 1;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void OnEnable()
        {
            _rigidbody2D.AddForce(Vector2.up * 200);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            

            if (collision.HasHitPlayer())
            {
                GameManager.Instance.IncreaseScore(score);
                Destroy(this.gameObject);

            }
        }


    }

}
