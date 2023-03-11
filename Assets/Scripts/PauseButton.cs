using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _popupMenu;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPause);
        }

        private void OnPause()
        {
            //остановить таймер
            _popupMenu.SetActive(true);
        }
    }
}