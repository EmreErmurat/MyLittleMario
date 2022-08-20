using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Combats
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;

        public bool IsDead => currentHealth < 1;
        public event System.Action onHealthChanged;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            currentHealth -= damage.HitDamage;

            onHealthChanged?.Invoke();
        }
    }

}
