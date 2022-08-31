using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using MyLittleMario.Checkpoint;

namespace MyLittleMario.Light
{
    public class StatueIdleLightController : MonoBehaviour
    {

        Light2D _light2D;
        CheckpointController checkpointController;
        bool lightIncease = true;

        private void Awake()
        {
            _light2D = GetComponent<Light2D>();
            checkpointController = GetComponentInParent<CheckpointController>();

        }

        private void LateUpdate()
        {
            if (checkpointController.IsPassed)
            {
                if (lightIncease)
                {
                    _light2D.intensity += 5 * Time.deltaTime;
                    if (_light2D.intensity > 12)
                    {
                        lightIncease = false;
                    }
                }
                else
                {
                    _light2D.intensity -= 5 * Time.deltaTime;
                    if (_light2D.intensity < 1)
                    {
                        lightIncease = true;
                    }
                }
            }
            else
            {
                _light2D.intensity = 0;
            }


        }
    }
}
