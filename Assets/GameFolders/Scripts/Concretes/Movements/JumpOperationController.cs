using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpOperationController : MonoBehaviour
    {

        Rigidbody2D _rigidbody2D;

        [SerializeField] float _jumpforce = 350f;

        //public bool isJumpAction => _rigidbody2D.velocity != Vector2.zero;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        public void JumpAction()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _jumpforce);
        }


    }

}
