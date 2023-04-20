using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsToggleInMenuScene : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;
        [SerializeField] private List<Sprite> soundOnIcons;
        [SerializeField] private List<Sprite> soundOffIcons;
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
                iconIndex = Random.Range(0, soundOnIcons.Count);
            }

            if (on)
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = soundOnIcons[iconIndex];
            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = soundOffIcons[iconIndex];
            }
        }
    }
}