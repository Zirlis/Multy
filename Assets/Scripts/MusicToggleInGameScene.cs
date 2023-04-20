using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class MusicToggleInGameScene : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManager;
        [SerializeField] private List<Sprite> musicOnIcons;
        [SerializeField] private List<Sprite> musicOffIcons;
        private int iconIndex = -1;


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
            if (iconIndex == -1)
            {
                iconIndex = Random.Range(0, musicOnIcons.Count);
            }

            if (on)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = musicOnIcons[iconIndex];
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = musicOffIcons[iconIndex];
            }
        }
    }
}