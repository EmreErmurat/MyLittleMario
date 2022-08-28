using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Abstracts.Combats;
using MyLittleMario.Animations;


namespace MyLittleMario.Combats
{
    public class EnemyHealthContoller : Health
    {

        CharacterAnimationController characterAnimationController;

        public event System.Action enemyOnDead;

        private void Awake()
        {
            characterAnimationController = GetComponent<CharacterAnimationController>();

            currentHealth = maxHealth;
        }



        public override void TakeHit(Damage damage)
        {
            if (IsDead) return;

            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                characterAnimationController.DyingAnimation();
                enemyOnDead?.Invoke();
               
            }
        }


    }

}
