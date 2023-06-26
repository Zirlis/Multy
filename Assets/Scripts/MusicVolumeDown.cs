using System.Collections;
using UnityEngine;

namespace Multipliers
{ 
    public class MusicVolumeDown : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        private float startVolume;

        private void Awake()
        {
            startVolume = _music.volume;
        }

        public void StartVolumeDown()
        {
            StartCoroutine(VolumeDown());
        }

        private IEnumerator VolumeDown()
        {
            while (_music.volume > 0)
            {
                _music.volume -= startVolume * Time.deltaTime;
                yield return null;
            }
        }
    }
}