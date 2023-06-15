using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class MusicToggleInMenuScene : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;
        [SerializeField] private List<Sprite> _musicOnIcons;
        [SerializeField] private List<Sprite> _musicOffIcons;
        private int _iconIndex = -1;


        private void Awake()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManager.Save();
            SetImage(on);
        }

        public void SetIsOn(bool on)
        {
            GetComponent<Toggle>().isOn = on;
            SetImage(on);
        }

        private void SetImage(bool on)
        {
            if(_iconIndex == -1)
            {
                _iconIndex = Random.Range(0, _musicOnIcons.Count);
            }

            if(on)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = _musicOnIcons[_iconIndex];
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = _musicOffIcons[_iconIndex];
            }
        }
    }
}