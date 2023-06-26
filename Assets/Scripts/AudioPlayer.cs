using UnityEngine;

namespace Multipliers
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio()
        {
            _audioSource.Play();
        }
    }
}