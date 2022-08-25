using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Combats
{
    public class HealthConrtoller : MonoBehaviour
    {
      

        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;

        public bool IsDead => currentHealth < 1;
        public event System.Action onHealthChanged;
        public event System.Action<int> healthDisplayPrinter;
        public event System.Action onDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Start()
        {
            healthDisplayPrinter?.Invoke(currentHealth);
        }

        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                onDead?.Invoke();
            }
            else
            {
                healthDisplayPrinter?.Invoke(currentHealth);
                onHealthChanged?.Invoke();
            }
        }
    }

}
