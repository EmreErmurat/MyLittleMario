using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Inputs
{
    public class PcInputsReceiver 
    {
        public float HorizontalInput => Input.GetAxis("Horizontal");
        public float VerticalInput => Input.GetAxis("Vertical");
        public bool JumpInput => Input.GetButtonDown("Jump");

        public bool EscInput => Input.GetKeyDown(KeyCode.Escape);

        public bool EInput => Input.GetKeyDown(KeyCode.E);

        public bool MouseZeroInput => Input.GetMouseButton(0);
    }
}

