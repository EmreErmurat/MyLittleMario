using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyLittleMario.Enums;
using MyLittleMario.Animations;
using MyLittleMario.Chest;


namespace MyLittleMario.Controllers
{
    public class ChestController : MonoBehaviour
    {
        ChestAnimationController chestAnimationController;
        ChestDropItemController chestDropItemController;

        [SerializeField] ChestType chestType;

        [SerializeField] GameObject UIcanvas;
        [SerializeField] ChestDetectionPlayer chestDetectionPlayer;

        bool chestIsOpen = false;

        private void Awake()
        {
            chestAnimationController = GetComponent<ChestAnimationController>();
            chestDropItemController = GetComponent<ChestDropItemController>();
        }

        private void Update()
        {
            if (chestDetectionPlayer.DetectionPlayer && !chestIsOpen)
            {
                UIcanvas.SetActive(true);
            }
            else
            {
                UIcanvas.SetActive(false);
            }


        }

        public void OpenChestAction()
        {
            chestAnimationController.ChestOpenAnimation(chestType.ToString());
            chestIsOpen = true;
            chestDropItemController.ItemDropAction();


        }












    }
}

