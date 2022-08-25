using MyLittleMario.Animations;
using MyLittleMario.Inputs;
using MyLittleMario.Movements;
using System.Collections;
using System.Collections.Generic;
using MyLittleMario.Combats;
using UnityEngine;
using MyLittleMario.Uis;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        PcInputsReceiver pcInputsReceiver;
        MoveOperationController moveOperationController;
        JumpOperationController jumpOperationController;
        CharacterAnimationController characterAnimationController;
        FlipChecker flipChecker;
        OnGroundChecker onGroundChecker;
        ClimbingOperationController climbingOperationController;
        HealthConrtoller healthConrtoller;
        GameMenuCanvasController gameMenuCanvasController;
        DisplayHealthAndScore displayHealthAndScore;
        Damage damage;
        

        float _horizontalInputHandler;
        float _verticalInputHandler;
        bool _jumpInputHandler;
        bool _canJump;
        
        
        private void Awake()
        {
            pcInputsReceiver = new PcInputsReceiver();
            moveOperationController = GetComponent<MoveOperationController>();
            jumpOperationController = GetComponent<JumpOperationController>();
            characterAnimationController = GetComponent<CharacterAnimationController>();
            flipChecker = GetComponent<FlipChecker>();
            onGroundChecker = GetComponent<OnGroundChecker>();
            climbingOperationController = GetComponent<ClimbingOperationController>();
            healthConrtoller = GetComponent<HealthConrtoller>();
            gameMenuCanvasController = FindObjectOfType<GameMenuCanvasController>();
            damage = GetComponent<Damage>();

            if (gameMenuCanvasController != null)
            {
                displayHealthAndScore = gameMenuCanvasController.GetComponentInChildren<DisplayHealthAndScore>();
            }
        }
        private void OnEnable()
        {
            if (gameMenuCanvasController != null)
            {
                healthConrtoller.onDead += gameMenuCanvasController.GameOverPanelOpen;
                healthConrtoller.healthDisplayPrinter += displayHealthAndScore.HealthValuePrint;
               
            }
            
        }

        private void OnDisable()
        {
            if (gameMenuCanvasController != null)
            {
                healthConrtoller.onDead -= gameMenuCanvasController.GameOverPanelOpen;
                healthConrtoller.healthDisplayPrinter -= displayHealthAndScore.HealthValuePrint;
            }

        }
        private void Update()
        {
            //InputHandler
            _horizontalInputHandler = pcInputsReceiver.HorizontalInput;
            _verticalInputHandler = pcInputsReceiver.VerticalInput;
            _jumpInputHandler = pcInputsReceiver.JumpInput;

            if (healthConrtoller.IsDead) return;
            

            

            PlayerMove();
            PlayerJump();

            characterAnimationController.JumpAnimation(onGroundChecker.IsOnGround);
            characterAnimationController.ClimbingAnimation(climbingOperationController.IsClimbing, _verticalInputHandler);
        }

        private void FixedUpdate()
        {

            //FlipControl
            flipChecker.FlipCharacter(_horizontalInputHandler);


            //JumpAction
            if (_canJump && !climbingOperationController.IsClimbing)
            {
                jumpOperationController.JumpAction();
                _canJump = false;
                
            }

            climbingOperationController.ClimbAction(_verticalInputHandler);

        }

        void PlayerMove()
        {
            if (_horizontalInputHandler != 0)
            {
                moveOperationController.HorizontalMoveAction(_horizontalInputHandler);

                characterAnimationController.MoveAnimation(_horizontalInputHandler);
                
            }
        }

        void PlayerJump()
        {
            if (_jumpInputHandler && onGroundChecker.IsOnGround && !climbingOperationController.IsClimbing)
            {
                _canJump = true;
                characterAnimationController.JumpAnimation(onGroundChecker.IsOnGround);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HealthConrtoller _playerHealth = collision.ObjectHasHealth();

            if (_playerHealth != null && collision.WasHitTopSide())
            {
                _playerHealth.TakeHit(damage);
                jumpOperationController.JumpAction();
            }
        }


    }
}

