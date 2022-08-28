using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Abstracts.Combats;
using MyLittleMario.Animations;

namespace MyLittleMario.Combats
{
    public class PlayerHealthController : Health
    {
        CharacterAnimationController characterAnimationController;

        Rigidbody2D _rigidbody2D;


        public event System.Action onHealthChanged;
        public event System.Action<int> healthDisplayPrinter;
        public event System.Action onDead;

        
        private void Awake()
        {
            characterAnimationController = GetComponent<CharacterAnimationController>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            currentHealth = maxHealth;
        }

        private void Start()
        {
            healthDisplayPrinter?.Invoke(currentHealth);
        }


        public override void TakeHit(Damage damage)
        {
            if (IsDead) return;
            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                StopPlayer(true);
                StartCoroutine(DeadActionAsync());
            }
            else
            {
                StopPlayer(true);
                StartCoroutine(HurtActionAsync());

            }
        }

        private IEnumerator HurtActionAsync()
        {

            characterAnimationController.HurtAnimation();
            yield return new WaitForSeconds(.5f);

            healthDisplayPrinter?.Invoke(currentHealth);
            onHealthChanged?.Invoke();

            StopPlayer(false);
        }

        private IEnumerator DeadActionAsync()
        {
            characterAnimationController.DyingAnimation();

            yield return new WaitForSeconds(.8f);

            onDead?.Invoke();

            Destroy(this.gameObject);
            //StopPlayer(false);
        }

        private void StopPlayer(bool value)
        {
            if (value)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                canMove = false;
            }
            else
            {
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                canMove = true;

            }
        }

    }

}
