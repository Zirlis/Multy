using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace Multipliers
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _popupMenu;
        [SerializeField] private Timer _timer;
        [SerializeField] private TextMeshProUGUI _currentScore;
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;
        [SerializeField] private List<Sprite> _pauseButtonIcons;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPause);

            int _iconIndex = Random.Range(0, _pauseButtonIcons.Count);
            gameObject.GetComponent<Image>().sprite = _pauseButtonIcons[_iconIndex];
        }

        private void OnPause()
        {
            _timer.StopTimer();

            _currentScore.SetText($"{_saveManagerGameScene.GameData.LastGameScore}");
            _popupMenu.SetActive(true);
        }
    }
}