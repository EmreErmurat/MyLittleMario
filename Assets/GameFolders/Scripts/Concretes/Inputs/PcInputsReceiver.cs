using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Inputs
{
    public class PcInputsReceiver 
    {
        public float HorizontalInput => Input.GetAxis("Horizontal");
        public bool JumpInput => Input.GetButtonDown("Jump");
    }
}

