using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        Animator _animator;



        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);

            if (_animator.GetFloat("moveSpeed") == mathfValue) return;
            _animator.SetFloat("moveSpeed", mathfValue);
        }


        public void JumpAnimatoin(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) ;
            _animator.SetBool("isJump", isJump);
        }

    }

}
