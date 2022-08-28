using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyLittleMario.Controllers
{
    public class WallController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController playerController = collision.collider.GetComponent<PlayerController>();

            if (playerController != null)
            {
                
                collision.collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

}
