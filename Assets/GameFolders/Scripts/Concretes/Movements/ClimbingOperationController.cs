using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    public class ClimbingOperationController : MonoBehaviour
    {
        [SerializeField] float climbSpeed = 5f;

        Rigidbody2D _rigidbody2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public bool IsClimbing { get; set; }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();




        }


        public void ClimbAction(float direction)
        {
            if (IsClimbing)
            {
                _rigidbody2D.velocity = Vector2.zero;
                transform.Translate(Vector2.up * direction * Time.deltaTime * climbSpeed);
            }

           
        }
    }

}
