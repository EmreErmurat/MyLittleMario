using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyLittleMario.Movements
{
    public class OnWallDetector : MonoBehaviour
    {
        FlipChecker flipChecker;
        Transform playerTransform;


        [SerializeField] Transform rightHand;
        [SerializeField] LayerMask layerMask;
        

        [SerializeField] bool onWall = false;
        

        float maxDistance = 0.18f;

        public bool OnWall => onWall;

        private void Awake()
        {
            flipChecker = GetComponent<FlipChecker>();
            playerTransform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {

            CheckHandOnWall(rightHand);


          


        }


        private void CheckHandOnWall(Transform HandTransform)
        {
            RaycastHit2D hit = Physics2D.Raycast(HandTransform.position, FindDirection(Vector2.right), maxDistance, layerMask);

            Debug.DrawRay(HandTransform.position, FindDirection(Vector2.right) * maxDistance, Color.red);

            if (hit.collider != null)
            {
                onWall = true;
            }
            else
            {
                onWall = false;
            }
        }
       

        private Vector2 FindDirection(Vector2 vector2)
        {
            return vector2 * transform.localScale.x;
        }

    }

}
