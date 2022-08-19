using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Movements;
using MyLittleMario.Inputs;

namespace MyLittleMario.Controllers
{
    public class LadderController : MonoBehaviour
    {

        PcInputsReceiver PcInputsReceiver;

        private void Awake()
        {
            PcInputsReceiver = new PcInputsReceiver();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (PcInputsReceiver.VerticalInput != 0f)
            {
                EnterExitOnTrigger(collision, 0, true);
            }
            
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (PcInputsReceiver.VerticalInput != 0f)
            {
                EnterExitOnTrigger(collision, 0, true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            EnterExitOnTrigger(collision, 1, false);
        }

        private void EnterExitOnTrigger(Collider2D collision, float gravityForce, bool isClimging)
        {
            ClimbingOperationController _playerClimbing = collision.GetComponent<ClimbingOperationController>();

            if (_playerClimbing != null)
            {
                
                _playerClimbing.Rigidbody2D.gravityScale = gravityForce;
                _playerClimbing.IsClimbing = isClimging;
            }
        }
    }

}
