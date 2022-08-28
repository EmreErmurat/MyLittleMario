using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    public class FlipChecker : MonoBehaviour
    {
       

        public void FlipCharacter(float horizontalInput)
        {
            if (horizontalInput != 0)
            {
                float mathfValue = Mathf.Sign(horizontalInput);
                if (transform.localScale.x == mathfValue) return;
                transform.localScale = new Vector2(mathfValue, 1);
                
            }

        }
    }

}
