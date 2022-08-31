using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Controllers;
using MyLittleMario.Combats;
using MyLittleMario.Checkpoint;


namespace MyLittleMario.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        CheckpointController[] checkpointControllersList;
        PlayerHealthController playerHealthController;

        public event System.Action ClearCheckpointHandler;

        private void Awake()
        {
            checkpointControllersList = GetComponentsInChildren<CheckpointController>();
            playerHealthController = FindObjectOfType<PlayerController>().GetComponent<PlayerHealthController>();
        }

        private void OnEnable()
        {
            playerHealthController.onHealthChanged += HandlerHealthChanged;

        }

        private void OnDisable()
        {
            playerHealthController.onHealthChanged -= HandlerHealthChanged;
        }

        void HandlerHealthChanged()
        {
            Transform _newTransform = FindCheckpointTransform();

            if (_newTransform != null)
            {
                playerHealthController.transform.position = _newTransform.position;
            }
            else
            {
                playerHealthController.transform.position = playerHealthController.transform.position;
            }
        }

        public void ClearCheckpointAction()
        {
            ClearCheckpointHandler?.Invoke();
        }
       
        private Transform FindCheckpointTransform()
        {
            foreach (var checkpoint in checkpointControllersList)
            {
                if (checkpoint.IsPassed)
                {
                    return checkpoint.SpawnTransfom;
                    
                }
                
            }
            return null;
        }
    }
}
