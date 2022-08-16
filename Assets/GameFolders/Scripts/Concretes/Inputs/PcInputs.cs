using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Inputs
{
    public class PcInputs 
    {

        public float Horizontal => Input.GetAxis("Horizontal");
        public bool Jump => Input.GetButtonDown("Jump");




    }
}

