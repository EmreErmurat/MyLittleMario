using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyLittleMario.Combats;
using MyLittleMario.Controllers;
using System;
using System.Linq;
using MyLittleMario.Animations;
using MyLittleMario.Uis;

namespace MyLittleMario.Uis
{
    public class DisplayHealthAndScore : MonoBehaviour
    {   
        
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] GameObject healthGrid;
        [SerializeField] GameObject healthPrefab;



        private void OnEnable()
        {
            GameManager.Instance.scorePrinter += ScoreValuePrint;
            GameManager.Instance.IncreaseScore(0);
        }


        private void OnDisable()
        {
            GameManager.Instance.scorePrinter -= ScoreValuePrint;

        }


        public void ScoreValuePrint(int score)
        {
            scoreText.text = score.ToString();
        }


        public void DisplayHealthValue(int currentHealth)
        {
            Transform[] healthList = healthGrid.transform.GetComponentsInChildren<Transform>();
            
            
            int _availableHealth = healthList.Length - 1; // -1 because [0] is parent

            if (currentHealth < _availableHealth)
            {
                GameObject health = healthList[_availableHealth].gameObject;
                health.GetComponent<UiAnimationController>().HealthDisappear();
                health.GetComponent<HealthUiLifeCircle>().KillHealthUiImage();
            }
            else if (currentHealth > _availableHealth)
            {
                for (int i = 0; i < currentHealth - (_availableHealth); i++)
                {
                    Instantiate(healthPrefab, healthGrid.transform.position, healthGrid.transform.rotation, healthGrid.transform);
                }
            }

            
        }


    }

}
