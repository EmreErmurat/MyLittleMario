using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLittleMario.Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] AudioSource audioSourceMusic;
        [SerializeField] AudioSource audioSourceSFX;

        [SerializeField] AudioClip enemyDeadSound;
        [SerializeField] AudioClip playerDeadSound;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void PlayOneShot(SoundType soundType)
        {

            switch (soundType)
            {
                case SoundType.enemyDead:
                    audioSourceSFX.PlayOneShot(playerDeadSound);
                    break;
                case SoundType.playerDead:
                    audioSourceSFX.PlayOneShot(enemyDeadSound);
                    break;
                default:
                    break;
            }

            
           
        }







    }

    public enum SoundType
    {
        playerDead,
        enemyDead
    }
}
