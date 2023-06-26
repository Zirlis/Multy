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
        [SerializeField] private NewInLine _newInLine;
        [SerializeField] private AudioPlayer _pageTurning;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPause);

            int _iconIndex = Random.Range(0, _pauseButtonIcons.Count);
            gameObject.GetComponent<Image>().sprite = _pauseButtonIcons[_iconIndex];
        }

        private void OnPause()
        {
            _timer.StopTimer();
            _pageTurning.PlayAudio();

            _currentScore.SetText($"{_saveManagerGameScene.GameData.LastGameScore}");
            _popupMenu.SetActive(true);

            if (_newInLine.LastTouched != null)
            {
                var TMPOfLastTouched = _newInLine.LastTouched.GetComponent<TextMeshProUGUI>();

                if (TMPOfLastTouched.text != "")
                {
                    _newInLine.LastTouched.GetComponent<AddBeginDrag>().BeginDrag = false;
                    _newInLine.RecalculationOnEndDrag(_newInLine.LastTouched,
                        _newInLine.LastTouched.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                    _newInLine.CollisionWithSomethingOtherThanBack = false;
                }
            }
        }
    }
}