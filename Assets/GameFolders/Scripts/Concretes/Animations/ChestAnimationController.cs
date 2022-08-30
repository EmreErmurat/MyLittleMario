using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Animations
{
    public class ChestAnimationController : MonoBehaviour
    {
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void ChestOpenAnimation(string chestName)
        {
            _animator.SetTrigger(chestName);
        }


    }

}
