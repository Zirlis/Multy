using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class UnpauseButton : MonoBehaviour
    {
        [SerializeField] private Button _unpauseButton;
        [SerializeField] private GameObject _popupMenu;

        private void Awake()
        {
            _unpauseButton.onClick.AddListener(UnPause);
        }

        private void UnPause()
        {
            //возобновить таймер
            _popupMenu.SetActive(false);
        }
    }
}