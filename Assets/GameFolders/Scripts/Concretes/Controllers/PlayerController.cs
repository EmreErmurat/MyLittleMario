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
        PcInputs _pcInputs;
        Mover _mover;
        Jump _jump;
        PlayerAnimation _playerAnimation;
        CanFlip _canFlip;
        OnGround _onGround;
       

        float _horizontal;
        
        
        bool _isJump;

        
        private void Awake()
        {
            _pcInputs = new PcInputs();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _canFlip = GetComponent<CanFlip>();
            _onGround = GetComponent<OnGround>();

        }

        private void Update()
        {
            _horizontal = _pcInputs.Horizontal;

            if (_pcInputs.Jump && _onGround.IsOnGround)
            {
                _isJump = true;
                _playerAnimation.JumpAnimatoin(_jump.isJumpAction);
            }
        }

        private void FixedUpdate()
        {

            _playerAnimation.MoveAnimation(_horizontal);

            _mover.HorizontalAction(_horizontal);


            _canFlip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
                
            }

            _playerAnimation.JumpAnimatoin(_jump.isJumpAction);

        }


    }
}

