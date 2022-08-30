using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyLittleMario.Controllers;

namespace MyLittleMario.ExtensionMethods
{
    public static class TriggerExtensionMethod
    {
        
        public static bool HasDetectPlayer(this Collider2D collision)
        {
            return collision.GetComponent<PlayerController>();
        }



    }
}

