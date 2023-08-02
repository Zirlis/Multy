using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsToggleInGameScene : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManager;
        [SerializeField] private List<Sprite> _soundOnIcons;
        [SerializeField] private List<Sprite> _soundOffIcons;
        private int _iconIndex = -1;

        [Header("Audio")]
        [SerializeField] private AudioSource _popInAudioSource;
        [SerializeField] private AudioSource _popOutAudioSource;
        [SerializeField] private AudioSource _pageTurning01AudioSource;
        [SerializeField] private AudioSource _pageTurning02AudioSource;
        [SerializeField] private AudioSource _pageTurning03AudioSource;
        [SerializeField] private AudioSource _pageTurning04AudioSource;
        [SerializeField] private AudioSource _multiplierInAudioSource;
        [SerializeField] private AudioSource _multiplierOutAudioSource;
        [SerializeField] private AudioSource _penWritingAudioSource;
        [SerializeField] private AudioPlayer _popIn;
        [SerializeField] private AudioPlayer _popOut;


        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
        }

        private void OnDestroy()
        {
            GetComponent<Toggle>().onValueChanged.RemoveListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManager.Save();
            SetImage(on);

            _popInAudioSource.mute = !on;
            _popOutAudioSource.mute = !on;
            _pageTurning01AudioSource.mute = !on;
            _pageTurning02AudioSource.mute = !on;
            _pageTurning03AudioSource.mute = !on;
            _pageTurning04AudioSource.mute = !on;
            _multiplierInAudioSource.mute = !on;
            _multiplierOutAudioSource.mute = !on;
            _penWritingAudioSource.mute = !on;

            if (on)
            {
                _popOut.PlayAudio();
            }
            else
            {
                _popIn.PlayAudio();
            }
        }

        public void SetIsOn(bool on)
        {
            GetComponent<Toggle>().isOn = on;

            _popInAudioSource.mute = !on;
            _popOutAudioSource.mute = !on;
            _pageTurning01AudioSource.mute = !on;
            _pageTurning02AudioSource.mute = !on;
            _pageTurning03AudioSource.mute = !on;
            _pageTurning04AudioSource.mute = !on;
            _multiplierInAudioSource.mute = !on;
            _multiplierOutAudioSource.mute = !on;
            _penWritingAudioSource.mute = !on;

            SetImage(on);
        }

        private void SetImage(bool on)
        {
            if (_iconIndex == -1)
            {
                _iconIndex = Random.Range(0, _soundOnIcons.Count);
            }

            if (on)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = _soundOnIcons[_iconIndex];
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = _soundOffIcons[_iconIndex];
            }
        }
    }
}