using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyLittleMario.Combats;
using MyLittleMario.Controllers;

namespace MyLittleMario.Uis
{
    public class DisplayHealthAndScore : MonoBehaviour
    {
        
        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] TextMeshProUGUI scoreText;


        public void HealthValuePrint(int currentHealth)
        {
            healthText.text = currentHealth.ToString();
        }

        public void ScoreValuePrint(int score)
        {
            scoreText.text = score.ToString();
        }

        private void OnEnable()
        {
            GameManager.Instance.scorePrinter += ScoreValuePrint;
            GameManager.Instance.IncreaseScore(0);
        }
        private void OnDisable()
        {
            GameManager.Instance.scorePrinter -= ScoreValuePrint;

        }

    }

}
