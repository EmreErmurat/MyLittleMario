using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Controllers;
using MyLittleMario.Combats;
using System.Linq;

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
            playerHealthController.transform.position = checkpointControllersList.LastOrDefault(x => x.IsPassed).transform.position;
        }

        public void ClearCheckpointAction()
        {
            ClearCheckpointHandler?.Invoke();
        }
       
    }
}
