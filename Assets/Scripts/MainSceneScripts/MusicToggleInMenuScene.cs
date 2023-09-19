using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class MusicToggleInMenuScene : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;
        [SerializeField] private Sprite[] _musicOnIcons = new Sprite[10];
        [SerializeField] private Sprite[] _musicOffIcons = new Sprite[10];
        [SerializeField] private Image _toggleImage;
        private int _iconIndex;

        [Header("Audio")]
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioPlayer _popIn;
        [SerializeField] private AudioPlayer _popOut;


        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
            _iconIndex = Random.Range(0, _musicOnIcons.Length);
        }

        private void OnDestroy()
        {
            GetComponent<Toggle>().onValueChanged.RemoveListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManager.Save();

            _musicAudioSource.mute = !on;

            if (on)
            {
                _toggleImage.sprite = _musicOnIcons[_iconIndex];
                _popOut.PlayAudio();
            }
            else
            {
                _toggleImage.sprite = _musicOffIcons[_iconIndex];
                _popIn.PlayAudio();
            }
        }

        public void OnSwitch(bool on, bool doNotMakeASave)
        {
            GetComponent<Toggle>().isOn = on;
            _musicAudioSource.mute = !on;

            if (on)
                _toggleImage.sprite = _musicOnIcons[_iconIndex];
            else
                _toggleImage.sprite = _musicOffIcons[_iconIndex];
            
            if(!doNotMakeASave)
                _saveManager.Save();
        }
    }
}