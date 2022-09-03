using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Controllers;

namespace MyLittleMario.Combats
{
    public class ThrowWeaponController : MonoBehaviour
    {

        [SerializeField] Transform spearThrowLoc;
        [SerializeField] GameObject spearPrefab;

        [SerializeField] Transform  axeThrowLoc;
        [SerializeField] GameObject axePrefab;

        [SerializeField] Transform ThrownWeaponHolder; 
        [SerializeField] Transform dropWeaponHolder;
        public void ThrowWeaponAction(string weapon)
        {
            switch (weapon)
            {
                case "spear":
                    Instantiate(spearPrefab, spearThrowLoc.position, spearThrowLoc.rotation, ThrownWeaponHolder);
                    break;
                case "axe":
                    Instantiate(axePrefab, axeThrowLoc.position, axeThrowLoc.rotation, ThrownWeaponHolder);
                    break;
                default:
                    break;
            }
            
        }

        public void DropWeapon(string weapon)
        {
            switch (weapon)
            {
                case "spear":
                    Instantiate(spearPrefab, spearThrowLoc.position, spearThrowLoc.rotation, dropWeaponHolder);
                    break;
                case "axe":
                    Instantiate(axePrefab, axeThrowLoc.position, axeThrowLoc.rotation, dropWeaponHolder);
                    break;
                default:
                    break;
            }
        }



    }

}
