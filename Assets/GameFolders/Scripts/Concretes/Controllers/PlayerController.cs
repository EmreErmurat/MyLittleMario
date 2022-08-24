using MyLittleMario.Animations;
using MyLittleMario.Inputs;
using MyLittleMario.Movements;
using System.Collections;
using System.Collections.Generic;
using MyLittleMario.Combats;
using UnityEngine;
using MyLittleMario.Uis;

namespace MyLittleMario.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        PcInputsReceiver pcInputsReceiver;
        MoveOperationController moveOperationController;
        JumpOperationController JumpOperationController;
        PlayerAnimationController PlayerAnimationController;
        FlipChecker FlipChecker;
        OnGroundChecker OnGroundChecker;
        ClimbingOperationController ClimbingOperationController;
        PlayerHealth playerHealth;
        GameMenuCanvasController GameMenuCanvasController;
        DisplayHealthAndScore displayHealthAndScore;
        

        float _horizontalInputHandler;
        float _verticalInputHandler;
        bool _jumpInputHandler;
        bool _canJump;
        
        
        private void Awake()
        {
            pcInputsReceiver = new PcInputsReceiver();
            moveOperationController = GetComponent<MoveOperationController>();
            JumpOperationController = GetComponent<JumpOperationController>();
            PlayerAnimationController = GetComponent<PlayerAnimationController>();
            FlipChecker = GetComponent<FlipChecker>();
            OnGroundChecker = GetComponent<OnGroundChecker>();
            ClimbingOperationController = GetComponent<ClimbingOperationController>();
            playerHealth = GetComponent<PlayerHealth>();
            GameMenuCanvasController = FindObjectOfType<GameMenuCanvasController>();
            if (GameMenuCanvasController != null)
            {
                displayHealthAndScore = GameMenuCanvasController.GetComponentInChildren<DisplayHealthAndScore>();
            }
        }
        private void OnEnable()
        {
            if (GameMenuCanvasController != null)
            {
                playerHealth.onDead += GameMenuCanvasController.GameOverPanelOpen;
                playerHealth.healthDisplayPrinter += displayHealthAndScore.HealthValuePrint;
            }
            
        }

        private void OnDisable()
        {
            if (GameMenuCanvasController != null)
            {
                playerHealth.onDead -= GameMenuCanvasController.GameOverPanelOpen;
                playerHealth.healthDisplayPrinter -= displayHealthAndScore.HealthValuePrint;
            }

        }
        private void Update()
        {
            //InputHandler
            _horizontalInputHandler = pcInputsReceiver.HorizontalInput;
            _verticalInputHandler = pcInputsReceiver.VerticalInput;
            _jumpInputHandler = pcInputsReceiver.JumpInput;

            if (playerHealth.IsDead) return;
            

            

            PlayerMove();
            PlayerJump();
            
            PlayerAnimationController.JumpAnimation(OnGroundChecker.IsOnGround);
            PlayerAnimationController.ClimbingAnimation(ClimbingOperationController.IsClimbing, _verticalInputHandler);
        }

        private void FixedUpdate()
        {

            //FlipControl
            FlipChecker.FlipCharacter(_horizontalInputHandler);


            //JumpAction
            if (_canJump && !ClimbingOperationController.IsClimbing)
            {
                JumpOperationController.JumpAction();
                _canJump = false;
                
            }

            ClimbingOperationController.ClimbAction(_verticalInputHandler);

        }

        void PlayerMove()
        {
            if (_horizontalInputHandler != 0)
            {
                moveOperationController.HorizontalMoveAction(_horizontalInputHandler);

                PlayerAnimationController.MoveAnimation(_horizontalInputHandler);
                
            }
        }

        void PlayerJump()
        {
            if (_jumpInputHandler && OnGroundChecker.IsOnGround && !ClimbingOperationController.IsClimbing)
            {
                _canJump = true;
                PlayerAnimationController.JumpAnimation(OnGroundChecker.IsOnGround);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (damage != null)
            {
                playerHealth.TakeHit(damage);
                return;
            }
        }


    }
}

