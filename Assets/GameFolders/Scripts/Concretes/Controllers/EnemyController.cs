using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Movements;
using MyLittleMario.Animations;
using MyLittleMario.Combats;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Sound;
using MyLittleMario.Abstracts.Combats;

namespace MyLittleMario.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        MoveOperationController moveOperationController;
        CharacterAnimationController characterAnimationController;
        EnemyHealthContoller enemyHealthContoller;
        FlipChecker flipChecker;
        EdgeDetector edgeDetector;
        Damage damage;

        bool _isOnEdge;
        float _direction;

        private void Awake()
        {
            moveOperationController = GetComponent<MoveOperationController>();
            characterAnimationController = GetComponent<CharacterAnimationController>();
            enemyHealthContoller = GetComponent<EnemyHealthContoller>();
            flipChecker = GetComponent<FlipChecker>();
            edgeDetector = GetComponent<EdgeDetector>();
            damage = GetComponent<Damage>();

            _direction = 1f;

                       
        }

        private void OnEnable()
        {
            enemyHealthContoller.enemyOnDead += DeadAction;
        }
        private void FixedUpdate()
        {
            if (enemyHealthContoller.IsDead) return;

            moveOperationController.HorizontalMoveAction(_direction);

            characterAnimationController.MoveAnimation(_direction);
        }

        private void LateUpdate()
        {
            if (enemyHealthContoller.IsDead) return;

            if (edgeDetector.EdgeDetect())
            {
                _direction *= -1;
                flipChecker.FlipCharacter(_direction);
            }
           
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health _health = collision.ObjectHasHealth();

            if (_health != null && collision.WasHitLeftOrRightSide())
            {
                _health.TakeHit(damage);
            }
        }


        private void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {
            characterAnimationController.DyingAnimation();
            SoundManager.Instance.PlayOneShot(SoundType.enemyDead);
            yield return new WaitForSeconds(.6f);
            Destroy(this.gameObject);
        }



    }

    


}
