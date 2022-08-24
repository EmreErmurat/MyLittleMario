using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Controllers
{
    public class TreeQuitController : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>())
            {
                GameManager.Instance.ExitGame();
               
            }
        }
    }

}
