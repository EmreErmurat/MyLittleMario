using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationController : MonoBehaviour
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


        public void JumpAnimation(bool OnGround)
        {
            if (!OnGround == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", !OnGround);
        }



        public void ClimbingAnimation(bool isClimbing, float verticalInput)
        {
            float _mathfValueVertical = Mathf.Abs(verticalInput);
            
           // if (_animator.GetBool("isClimb") == isClimbing) return;
            
            _animator.SetFloat("climbSpeed", _mathfValueVertical);
            _animator.SetBool("isClimb", isClimbing);
        }


        public void DyingAnimation()
        {
            _animator.SetTrigger("dying");
        }

        public void HurtAnimation()
        {
            _animator.SetTrigger("hurting");
        }

        public void SlideWallAnimation(bool onWall, bool onGround)
        {
            if (_animator.GetBool("slide") == (onWall && !onGround)) return;
            _animator.SetBool("slide", (onWall && !onGround));
        }
    }

}
