using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SoundsMusicTogglesInGameScene : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;

        private void Start()
        {
            GetComponent<Toggle>().onValueChanged.AddListener(OnSwitch);
        }

        private void OnSwitch(bool on)
        {
            _saveManagerGameScene.Save();
        }
    }
}