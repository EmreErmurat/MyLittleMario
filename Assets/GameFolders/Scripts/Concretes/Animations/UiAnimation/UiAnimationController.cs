using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    public class UiAnimationController : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void HealthDisappear()
        {
            _animator.SetTrigger("healthOnDisable");
            
        }
    }

}
