using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyLittleMario.Movements
{
    public class Mover : MonoBehaviour
    {

        [SerializeField] float _moveSpeed = 5f;


        public void HorizontalAction(float horizontal)
        {
            
            transform.Translate(Vector2.right * horizontal * _moveSpeed * Time.deltaTime);
        }





    }
}

