using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsMusicToggles : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;

        private void Start()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManager.Save();
        }
    }
}