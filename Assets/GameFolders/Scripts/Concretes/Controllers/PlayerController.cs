using MyLittleMario.Animations;
using MyLittleMario.Inputs;
using MyLittleMario.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        

        float _horizontalInputHandler;
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

        }

        private void Update()
        {
            //InputHandler
            _horizontalInputHandler = pcInputsReceiver.HorizontalInput;
            _jumpInputHandler = pcInputsReceiver.JumpInput;


            PlayerMove();
            PlayerJump();

        }

        private void FixedUpdate()
        {

            //FlipControl
            FlipChecker.FlipCharacter(_horizontalInputHandler);


            //JumpAction
            if (_canJump)
            {
                JumpOperationController.JumpAction();
                _canJump = false;
                
            }

            PlayerAnimationController.JumpAnimation(JumpOperationController.isJumpAction);

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
            if (_jumpInputHandler && OnGroundChecker.IsOnGround)
            {
                _canJump = true;
                PlayerAnimationController.JumpAnimation(JumpOperationController.isJumpAction);
            }
        }

    }
}

