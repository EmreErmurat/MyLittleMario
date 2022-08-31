using MyLittleMario.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Animations;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Checkpoint
{
    public class CheckpointController : MonoBehaviour
    {
        CheckpointManager checkpointManager;
        CheckpointAnimationController checkpointAnimationController;
        [SerializeField] Transform spawnTransform;

        bool _isPassed = false;

        public Transform SpawnTransfom => spawnTransform;

        public bool IsPassed => _isPassed;

        private void Awake()
        {
            checkpointManager = GetComponentInParent<CheckpointManager>();
            checkpointAnimationController = GetComponent<CheckpointAnimationController>();
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
            if (collision.HasDetectPlayer())
            {
                if (!IsPassed)
                {
                    checkpointAnimationController.CheckpointActivationAnimation();
                }
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

