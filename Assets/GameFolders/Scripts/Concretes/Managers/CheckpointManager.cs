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
        HealthConrtoller healthConrtoller;

        public event System.Action ClearCheckpointHandler;

        private void Awake()
        {
            checkpointControllersList = GetComponentsInChildren<CheckpointController>();
            healthConrtoller = FindObjectOfType<PlayerController>().GetComponent<HealthConrtoller>();
        }

        private void OnEnable()
        {
            healthConrtoller.onHealthChanged += HandlerHealthChanged;

        }

        private void OnDisable()
        {
            healthConrtoller.onHealthChanged -= HandlerHealthChanged;
        }

        void HandlerHealthChanged()
        {
            healthConrtoller.transform.position = checkpointControllersList.LastOrDefault(x => x.IsPassed).transform.position;
        }

        public void ClearCheckpointAction()
        {
            ClearCheckpointHandler?.Invoke();
        }
       
    }
}
