using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Chest
{
    public class ChestDropItemController : MonoBehaviour
    {
        [SerializeField] GameObject[] itemPrefab;
   
        [SerializeField] Transform spawnPos;
        [SerializeField] Transform ThrownWeaponHolder;

        public void ItemDropAction()
        {
            StartCoroutine(ItemDropCoroutine());
        }

        private IEnumerator ItemDropCoroutine()
        {
            yield return new WaitForSeconds(0.3f);
            
            Instantiate(FindRandomItem(), spawnPos.position, spawnPos.rotation, ThrownWeaponHolder);
            


        }

        private GameObject FindRandomItem()
        {
            return itemPrefab[Random.Range(0, itemPrefab.Length)];
        }
    }

}

