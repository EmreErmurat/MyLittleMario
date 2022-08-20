using MyLittleMario.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Controllers
{
    public class CheckpointController : MonoBehaviour
    {
        CheckpointManager checkpointManager;

        bool _isPassed = false;


        public bool IsPassed => _isPassed;

        private void Awake()
        {
            checkpointManager = GetComponentInParent<CheckpointManager>();
        }

        private void OnEnable()
        {
            checkpointManager.ClearCheckpointHandler += ClearCheckpoint;
        }

       

        private void OnDisable()
        {
            checkpointManager.ClearCheckpointHandler -= ClearCheckpoint;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                checkpointManager.ClearCheckpointAction();
                _isPassed = true;
            }
        }



        private void ClearCheckpoint()
        {
            _isPassed = false;
        }


    }

}

