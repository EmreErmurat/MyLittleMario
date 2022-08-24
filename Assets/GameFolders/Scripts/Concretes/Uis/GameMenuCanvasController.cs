using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Inputs;
using MyLittleMario.Combats;
using MyLittleMario.Controllers;

namespace MyLittleMario.Uis
{
    public class GameMenuCanvasController : MonoBehaviour
    {

        PcInputsReceiver pcInputsReceiver;
              

        [SerializeField] GameObject mainMenuPanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject gameUiPanel;

        private void Awake()
        {
            pcInputsReceiver = new PcInputsReceiver();
            
        }

        private void Update()
        {
            if (pcInputsReceiver.EscInput && GameManager.Instance.ActiveSceneIndex != 0)
            {
                if (mainMenuPanel.activeSelf)
                {
                    mainMenuPanel.SetActive(false);
                }
                else
                {
                    mainMenuPanel.SetActive(true);
                }
                
            }

            if (!gameUiPanel.activeSelf && GameManager.Instance.ActiveSceneIndex != 0)
            {
                gameUiPanel.SetActive(true);
            }
            if (gameUiPanel.activeSelf && GameManager.Instance.ActiveSceneIndex == 0)
            {
                gameUiPanel.SetActive(false);
            }
        }


        public void RestartGameButtonClick()
        {
            GameManager.Instance.LoadScene(1);
            if (gameOverPanel.activeSelf)
            {
                GameOverPanelOpen();
            }
            
        }

        public void ResumeGameButtonClick()
        {
            mainMenuPanel.SetActive(false);
        }

        public void MainMenuButtonClick()
        {
            GameManager.Instance.LoadScene(0);
            mainMenuPanel.SetActive(false);
            if (gameOverPanel.activeSelf)
            {
                GameOverPanelOpen();
            }
            
        }

        public void ExitGameButtonClick()
        {
            GameManager.Instance.ExitGame();
        }

        public void GameOverPanelOpen()
        {
            if (gameOverPanel.activeSelf)
            {
                gameOverPanel.SetActive(false);
            }
            else
            {
                gameOverPanel.SetActive(true);
            }
            
        }




    }

}
