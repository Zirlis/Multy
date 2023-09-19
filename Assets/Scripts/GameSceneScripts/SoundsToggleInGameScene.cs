using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsToggleInGameScene : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManager;
        [SerializeField] private Sprite[] _soundOnIcons = new Sprite[10];
        [SerializeField] private Sprite[] _soundOffIcons = new Sprite[10];
        [SerializeField] private Image _toggleImage;
        private int _iconIndex;

        [Header("Audio")]
        [SerializeField] private AudioSource[] _sounds = new AudioSource[9];
        [SerializeField] private AudioPlayer _popIn;
        [SerializeField] private AudioPlayer _popOut;


        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
            _iconIndex = Random.Range(0, _soundOnIcons.Length);
        }

        private void OnDestroy()
        {
            GetComponent<Toggle>().onValueChanged.RemoveListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManager.Save();

            foreach (var sound in _sounds)
                sound.mute = !on;

            if (on)
            {
                _popOut.PlayAudio();
                _toggleImage.sprite = _soundOnIcons[_iconIndex];
            }
            else
            {
                _popIn.PlayAudio();
                _toggleImage.sprite = _soundOffIcons[_iconIndex];
            }
        }

        public void OnSwitch(bool on, bool doNotMakeASave)
        {
            GetComponent<Toggle>().isOn = on;

            foreach (var sound in _sounds)
                sound.mute = !on;

            if (on)
                _toggleImage.sprite = _soundOnIcons[_iconIndex];
            else
                _toggleImage.sprite = _soundOffIcons[_iconIndex];

            if (!doNotMakeASave)
                _saveManager.Save();
        }
    }
}