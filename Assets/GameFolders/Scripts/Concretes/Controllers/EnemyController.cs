using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Movements;
using MyLittleMario.Animations;
using MyLittleMario.Combats;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Sound;
using MyLittleMario.Abstracts.Combats;
using MyLittleMario.Enums;

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
        JumpOperationController jumpOperationController;
        PlayerDetector playerDetector;
        [SerializeField] EnemyType enemyType;
        Rigidbody2D _rigidbody2D;


        bool _isOnEdge;
        float _direction;
        [SerializeField] bool frogJumpAction = true;
        bool frogStand;

        bool eagleFlyUp = false;

        private void Awake()
        {
            moveOperationController = GetComponent<MoveOperationController>();
            characterAnimationController = GetComponent<CharacterAnimationController>();
            enemyHealthContoller = GetComponent<EnemyHealthContoller>();
            flipChecker = GetComponent<FlipChecker>();
            edgeDetector = GetComponent<EdgeDetector>();
            damage = GetComponent<Damage>();
            jumpOperationController = GetComponent<JumpOperationController>();
            playerDetector = GetComponent<PlayerDetector>();
            _rigidbody2D = GetComponent<Rigidbody2D>();

            _direction = 1f;


        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            enemyHealthContoller.enemyOnDead += DeadAction;

            if (enemyType == EnemyType.Eagle)
            {
                StartCoroutine(EagleLifeCircle());
            }
        }

        private void Update()
        {
            if (enemyType == EnemyType.Frog)
            {
                characterAnimationController.FrogIdle(frogStand);
            }
        }

        private void FixedUpdate()
        {
            if (enemyHealthContoller.IsDead) return;

            switch (enemyType)
            {
                case EnemyType.Opossum:

                    moveOperationController.HorizontalMoveAction(_direction);
                    characterAnimationController.MoveAnimation(_direction);

                    break;

                case EnemyType.Frog:

                    if (playerDetector.PlayerDetect && frogJumpAction)
                    {
                        frogJumpAction = false;
                        StartCoroutine(FrogJumpAction());
                    }
                    if (_rigidbody2D.velocity == Vector2.zero)
                    {
                        frogStand = true;
                    }
                    else
                    {
                        frogStand = false;
                    }

                    break;

                case EnemyType.Eagle:

                    moveOperationController.HorizontalMoveAction(_direction * -1);
                    characterAnimationController.FlyAnimation(_direction * -1);

                    if (eagleFlyUp)
                    {
                        moveOperationController.VerticalMoveAction();
                    }
                    break;

                default:
                    break;
            }

        }

        private void LateUpdate()
        {
            if (enemyHealthContoller.IsDead) return;

            if (enemyType == EnemyType.Opossum)
            {
                if (edgeDetector.EdgeDetect())
                {
                    _direction *= -1;
                    flipChecker.FlipCharacter(_direction);
                }
            }
             
           
        }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health _health = collision.ObjectHasHealth();

            if (_health != null && (collision.WasHitLeftOrRightSide() || collision.WasHitTopSide()))
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

        private IEnumerator FrogJumpAction()
        {
            yield return new WaitForSeconds(1f);
            jumpOperationController.FrogJump(transform.localScale.x);
            yield return new WaitForSeconds(3f);
            frogJumpAction = true;
            
        }


        private IEnumerator EagleLifeCircle()
        {
            yield return new WaitForSeconds(4f);
            eagleFlyUp = true;
            yield return new WaitForSeconds(6f);
            Destroy(this.gameObject);
        }

    }

    


}
