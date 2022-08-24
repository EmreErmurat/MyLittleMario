using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Controllers
{
    public class MenuStartGameLocationController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                GameManager.Instance.LoadScene(1);
            }
        }

    }

}
