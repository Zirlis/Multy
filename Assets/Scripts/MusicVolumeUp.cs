using System.Collections;
using UnityEngine;

namespace Multipliers
{
    public class MusicVolumeUp : MonoBehaviour
    {
        [SerializeField] private AudioSource _music;
        private float startVolume;

        private void Awake()
        {
            startVolume = _music.volume;
            _music.volume = 0;
        }

        private void Start()
        {
            StartCoroutine(VolumeUp());
        }

        private IEnumerator VolumeUp()
        {
            while (_music.volume < startVolume)
            {
                _music.volume += startVolume * Time.deltaTime;
                yield return null;
            }
        }
    }
}