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
        PlayerHealth playerHealth;

        public event System.Action ClearCheckpointHandler;

        private void Awake()
        {
            checkpointControllersList = GetComponentsInChildren<CheckpointController>();
            playerHealth = FindObjectOfType<PlayerController>().GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            playerHealth.onHealthChanged += HandlerHealthChanged;

        }

        private void OnDisable()
        {
            playerHealth.onHealthChanged -= HandlerHealthChanged;
        }

        void HandlerHealthChanged()
        {
            playerHealth.transform.position = checkpointControllersList.LastOrDefault(x => x.IsPassed).transform.position;
        }

        public void ClearCheckpointAction()
        {
            ClearCheckpointHandler?.Invoke();
        }
       
    }
}
