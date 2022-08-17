using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        Animator _animator;



        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        public void MoveAnimation(float horizontalInput)
        {
            float _mathfValue = Mathf.Abs(horizontalInput);

            if (_animator.GetFloat("moveSpeed") == _mathfValue) return;
            _animator.SetFloat("moveSpeed", _mathfValue);
        }


        public void JumpAnimation(bool JumpInput)
        {
            if (JumpInput == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", JumpInput);
        }






    }

}
