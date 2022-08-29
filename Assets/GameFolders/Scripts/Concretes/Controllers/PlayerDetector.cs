using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyLittleMario.Controllers
{
    
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] Collider2D detectionArea;
        EnemyController enemyController;
        public bool PlayerDetect { get; private set; }

        private void Awake()
        {
            enemyController = GetComponent<EnemyController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerDetect = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            

            if (collision.gameObject.tag == "Player")
            {

                

                if (transform.position.x > collision.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }

               // if (PlayerDetect == false) return;
                //PlayerDetect = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerDetect = false;
            
        }




    }

}
