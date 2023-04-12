using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Multipliers
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _popupMenu;
        [SerializeField] private Timer _timer;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPause);
        }

        private void OnPause()
        {
            _timer.StopTimer();

            _currentScore.SetText($"{_saveManagerGameScene.GameData.LastGameScore}");
            _popupMenu.SetActive(true);
        }
    }
}