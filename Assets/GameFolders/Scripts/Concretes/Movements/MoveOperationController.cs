using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    public class MoveOperationController : MonoBehaviour
    {

        [SerializeField] float _moveSpeed = 5f;


        public void HorizontalMoveAction(float horizontalInput)
        {

            transform.Translate(Vector2.right * horizontalInput * _moveSpeed * Time.deltaTime);
        }
    }

}
