using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpOperationController : MonoBehaviour
    {

        Rigidbody2D _rigidbody2D;

        float jumpforce = 400f;
        float horizontalForce = 100f;

       

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        public void JumpAction()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpforce);
        }


        public void WallJumpAction(float direction)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.right * direction * horizontalForce);
            _rigidbody2D.AddForce(Vector2.up * jumpforce);
            
            

        }

    }

}
