using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Combats;



namespace MyLittleMario.Abstracts.Combats
{
    public abstract class Health : MonoBehaviour
    {
       

        [SerializeField] protected int maxHealth = 3;
        [SerializeField] protected int currentHealth = 0;

        protected bool canMove = true;

        public bool IsDead => currentHealth < 1;
        public bool CanMove => canMove;


        public abstract void TakeHit(Damage damage);
        
    }

}
