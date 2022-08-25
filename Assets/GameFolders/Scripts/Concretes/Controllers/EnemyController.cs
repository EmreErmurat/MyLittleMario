using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Movements;
using MyLittleMario.Animations;
using MyLittleMario.Combats;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        MoveOperationController moveOperationController;
        CharacterAnimationController characterAnimationController;
        HealthConrtoller healthConrtoller;
        FlipChecker flipChecker;
        EdgeDetector edgeDetector;
        Damage damage;

        bool _isOnEdge;
        float _direction;

        private void Awake()
        {
            moveOperationController = GetComponent<MoveOperationController>();
            characterAnimationController = GetComponent<CharacterAnimationController>();
            healthConrtoller = GetComponent<HealthConrtoller>();
            flipChecker = GetComponent<FlipChecker>();
            edgeDetector = GetComponent<EdgeDetector>();
            damage = GetComponent<Damage>();

            _direction = 1f;
        }

        private void OnEnable()
        {
            healthConrtoller.onDead += DeadAction;
        }
        private void FixedUpdate()
        {
            if (healthConrtoller.IsDead) return;

            moveOperationController.HorizontalMoveAction(_direction);

            characterAnimationController.MoveAnimation(_direction);
        }

        private void LateUpdate()
        {
            if (healthConrtoller.IsDead) return;

            if (edgeDetector.EdgeDetect())
            {
                _direction *= -1;
                flipChecker.FlipCharacter(_direction);
            }
           
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthConrtoller _playerHealth = collision.ObjectHasHealth();

            if (_playerHealth != null && collision.WasHitLeftOrRightSide())
            {
                _playerHealth.TakeHit(damage);
            }
        }


        private void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {
            characterAnimationController.DyingAnimation();
            yield return new WaitForSeconds(.6f);
            Destroy(this.gameObject);
        }



    }

    


}
