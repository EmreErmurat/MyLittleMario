
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Movements
{
    public class OnGround : MonoBehaviour
    {
        [SerializeField] bool _isOnGround = false;
        [SerializeField] Transform[] translates;
        [SerializeField] float maxDistance = 0.15f;
        [SerializeField] LayerMask _layerMask;

        public bool IsOnGround => _isOnGround;

        private void Update()
        {
            foreach (Transform footTransform in translates)
            {

                CheckFootOnGround(footTransform);

                if (_isOnGround) break;
                                
            }


        }

        private void CheckFootOnGround(Transform footTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, maxDistance, _layerMask);

            Debug.DrawRay(footTransform.position, footTransform.forward * maxDistance, Color.red);

            if (hit.collider != null)
            {
                _isOnGround = true;
            }
            else
            {
                _isOnGround = false;
            }
        }
    }

}
