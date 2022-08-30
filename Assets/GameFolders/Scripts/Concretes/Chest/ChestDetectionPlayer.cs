using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Controllers;
using MyLittleMario.ExtensionMethods;

namespace MyLittleMario.Chest
{
    public class ChestDetectionPlayer : MonoBehaviour
    {
        ChestController chestController;

        public bool DetectionPlayer { get; private set; }

        private void Awake()
        {
            chestController = GetComponentInParent<ChestController>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            

            if (collision.HasDetectPlayer())
            {
                DetectionPlayer = true;
                collision.GetComponent<PlayerController>().NearChestDefiner(chestController);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {


            if (collision.HasDetectPlayer())
            {
                DetectionPlayer = false;
                collision.GetComponent<PlayerController>().NearChestDefiner();
            }
        }
    }

}


