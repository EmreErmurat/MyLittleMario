using MyLittleMario.Animations;
using MyLittleMario.Inputs;
using MyLittleMario.Movements;
using System.Collections;
using System.Collections.Generic;
using MyLittleMario.Combats;
using UnityEngine;
using MyLittleMario.Uis;
using MyLittleMario.ExtensionMethods;
using MyLittleMario.Abstracts.Combats;
using MyLittleMario.Chest;


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
        PlayerHealthController playerHealthController;
        GameMenuCanvasController gameMenuCanvasController;
        DisplayHealthAndScore displayHealthAndScore;
        Damage damage;
        OnWallDetector onWallDetector;
        ChestController nearChestController;
        ThrowWeaponController throwWeaponController;

        Rigidbody2D _rigidbody2D;
        Transform _transform;

        [SerializeField] GameObject SpearHolder;
        [SerializeField] GameObject AxeHolder;

        //Input
        float _horizontalInputHandler;
        float _verticalInputHandler;
        bool _jumpInputHandler;
        bool _eKeyInputHandler;
        bool _mouseZeroDownHandler;

        //Action
        bool _canJump;
        bool _canWallJump;
        bool _canThrowWeapon;

        //Throw Weapon
        bool doesHaveSpear = true;
        bool doesHaveAxe = false;

        public float PlayerDirection { get;private set; }


        private void Awake()
        {
            pcInputsReceiver = new PcInputsReceiver();
            moveOperationController = GetComponent<MoveOperationController>();
            jumpOperationController = GetComponent<JumpOperationController>();
            characterAnimationController = GetComponent<CharacterAnimationController>();
            flipChecker = GetComponent<FlipChecker>();
            onGroundChecker = GetComponent<OnGroundChecker>();
            climbingOperationController = GetComponent<ClimbingOperationController>();
            playerHealthController = GetComponent<PlayerHealthController>();
            gameMenuCanvasController = FindObjectOfType<GameMenuCanvasController>();
            damage = GetComponent<Damage>();
            onWallDetector = GetComponent<OnWallDetector>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
            throwWeaponController = GetComponent<ThrowWeaponController>();

            if (gameMenuCanvasController != null)
            {
                displayHealthAndScore = gameMenuCanvasController.GetComponentInChildren<DisplayHealthAndScore>();
            }
        }
        private void OnEnable()
        {
            if (gameMenuCanvasController != null)
            {
                playerHealthController.onDead += gameMenuCanvasController.GameOverPanelOpen;
                //playerHealthController.healthDisplayPrinter += displayHealthAndScore.HealthValuePrint;
                playerHealthController.healthDisplayPrinter += displayHealthAndScore.DisplayHealthValue;
            }

            GameManager.Instance.SetPlayer(this.gameObject);
            
        }

        private void OnDisable()
        {
            if (gameMenuCanvasController != null)
            {
                playerHealthController.onDead -= gameMenuCanvasController.GameOverPanelOpen;
                //playerHealthController.healthDisplayPrinter -= displayHealthAndScore.HealthValuePrint;
                playerHealthController.healthDisplayPrinter += displayHealthAndScore.DisplayHealthValue;
            }

        }
        private void Update()
        {
            

            //InputHandler
            _horizontalInputHandler = pcInputsReceiver.HorizontalInput;
            _verticalInputHandler = pcInputsReceiver.VerticalInput;
            _jumpInputHandler = pcInputsReceiver.JumpInput;
            _eKeyInputHandler = pcInputsReceiver.EInput;
            _mouseZeroDownHandler = pcInputsReceiver.MouseZeroInput;

            if (playerHealthController.IsDead || !playerHealthController.CanMove) return;



            PlayerJump();
            WallJump();
            SlideWall();


            characterAnimationController.JumpAnimation(onGroundChecker.IsOnGround);
            characterAnimationController.ClimbingAnimation(climbingOperationController.IsClimbing, _verticalInputHandler);

            // Chest

            if (_eKeyInputHandler && nearChestController != null)
            {
                nearChestController.OpenChestAction();
            }

            //throwWeapon

            if (_mouseZeroDownHandler && (doesHaveSpear || doesHaveAxe))
            {
                _canThrowWeapon = true;
            }

            
        }

        private void FixedUpdate()
        {
            PlayerDirection = _transform.localScale.x;
            
            PlayerMove();
            
            climbingOperationController.ClimbAction(_verticalInputHandler);

            //FlipControl
            flipChecker.FlipCharacter(_horizontalInputHandler);


            //JumpAction
            if (_canJump)
            {
                jumpOperationController.JumpAction();
                _canJump = false;
                
            }

            if (_canWallJump)
            {
               
              
                _transform.localScale = new Vector2(_transform.localScale.x * -1, _transform.localScale.y);
                jumpOperationController.WallJumpAction(_transform.localScale.x);

                _canWallJump = false;
            }

            if (_canThrowWeapon)
            {
                ThrowWeaponAction();
            }


        }

        void PlayerMove()
        {
            if (_horizontalInputHandler != 0 && playerHealthController.CanMove)
            {
                moveOperationController.HorizontalMoveAction(_horizontalInputHandler);
                characterAnimationController.MoveAnimation(_horizontalInputHandler);

                if (_rigidbody2D.velocity.x == 0 && _horizontalInputHandler !> 0.5F || _horizontalInputHandler !> -0.5F) return;
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
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

        void WallJump()
        {
            
            if (_jumpInputHandler && !onGroundChecker.IsOnGround && onWallDetector.OnWall && !climbingOperationController.IsClimbing)
            {
                
                _canWallJump = true;
                
            }
        }

        void SlideWall()
        {
            if (!onGroundChecker.IsOnGround && onWallDetector.OnWall)
            {
                
                characterAnimationController.SlideWallAnimation(onWallDetector.OnWall, onGroundChecker.IsOnGround);
               
            }
            else
            {

                characterAnimationController.SlideWallAnimation(onWallDetector.OnWall, onGroundChecker.IsOnGround);

            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health _health = collision.ObjectHasHealth();
            

            if (_health != null && collision.WasHitTopSide())
            {
                _health.TakeHit(damage);
                jumpOperationController.JumpAction();
            }

            if (collision.collider.GetComponent<SpearController>() != null)
            {
                if (doesHaveSpear || doesHaveAxe)
                {
                    throwWeaponController.DropWeapon(DropWeaponFinder());
                }

                doesHaveSpear = true;
                Destroy(collision.gameObject);
            }

            if (collision.collider.GetComponent<AxeController>() != null)
            {
                if (doesHaveAxe || doesHaveSpear )
                {
                    throwWeaponController.DropWeapon(DropWeaponFinder());
                }

                doesHaveAxe = true;
                Destroy(collision.gameObject);
            }

            WeaponHolderContoller();

        }


        string DropWeaponFinder()
        {

            if (doesHaveSpear)
            {
                doesHaveSpear = false;
                return "spear";
            }
            else if (doesHaveAxe)
            {
                doesHaveAxe = false;
                return "axe";
            }
            return null;
        }
        
        public void NearChestDefiner(ChestController chestController = null)
        {
            nearChestController = chestController;
        }



        void ThrowWeaponAction()
        {
            // ThrowWeapon

            if (doesHaveSpear)
            {
                throwWeaponController.ThrowWeaponAction("spear");
                _canThrowWeapon = false;
                doesHaveSpear = false;
            }

            if (doesHaveAxe)
            {
                throwWeaponController.ThrowWeaponAction("axe");
                _canThrowWeapon = false;
                doesHaveAxe = false;
            }

            WeaponHolderContoller();
        }

        void WeaponHolderContoller()
        {
            SpearHolder.SetActive(doesHaveSpear);
            AxeHolder.SetActive(doesHaveAxe);

        }
    }
}

