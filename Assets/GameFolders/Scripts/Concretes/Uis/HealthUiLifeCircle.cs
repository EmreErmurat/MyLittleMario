using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Uis
{
    public class HealthUiLifeCircle : MonoBehaviour
    {

        public void KillHealthUiImage()
        {
            StartCoroutine(HealtLifeTime());
        }

        IEnumerator HealtLifeTime()
        {
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);

        }
    }

}
