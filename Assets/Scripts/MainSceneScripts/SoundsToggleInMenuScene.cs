using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsToggleInMenuScene : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;
        [SerializeField] private List<Sprite> _soundOnIcons;
        [SerializeField] private List<Sprite> _soundOffIcons;
        private int _iconIndex = -1;

        [Header("Audio")]
        [SerializeField] private AudioSource _popInAudioSource;
        [SerializeField] private AudioSource _popOutAudioSource;
        [SerializeField] private AudioSource _pageTurningAudioSource;
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
            _pageTurningAudioSource.mute = !on;

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
            _pageTurningAudioSource.mute = !on;
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