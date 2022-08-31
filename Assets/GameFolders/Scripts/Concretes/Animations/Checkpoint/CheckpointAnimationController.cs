using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    public class CheckpointAnimationController : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void CheckpointActivationAnimation()
        {
            _animator.SetTrigger("CheckpointActivation");
        }


    }

}
