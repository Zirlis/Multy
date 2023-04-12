using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class UnpauseButton : MonoBehaviour
    {
        [SerializeField] private Button _unpauseButton;
        [SerializeField] private GameObject _popupMenu;
        [SerializeField] private Timer _timer;

        private void Awake()
        {
            _unpauseButton.onClick.AddListener(UnPause);
        }

        private void UnPause()
        {
            _popupMenu.SetActive(false);

            _timer.StartTimer();
        }
    }
}