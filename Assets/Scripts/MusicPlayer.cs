using UnityEngine;

namespace Multipliers
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioPlayer _music;

        private void Start()
        {
            _music.PlayAudio();
        }
    }
}