using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class Victory : MonoBehaviour
    {
        [Header("Compositions")]
        [SerializeField] private TextMeshProUGUI _firstCompositionRight;
        [SerializeField] private TextMeshProUGUI _firstCompositionLeft;
        [SerializeField] private TextMeshProUGUI _secondCompositionRight;
        [SerializeField] private TextMeshProUGUI _secondCompositionLeft;
        [SerializeField] private TextMeshProUGUI _thirdCompositionRight;
        [SerializeField] private TextMeshProUGUI _thirdCompositionLeft;

        [Header("VictoryPanel")]
        [SerializeField] private RectTransform _victoryPanel;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Image _randomImageOnVicroryPanel1;
        [SerializeField] private Image _randomImageOnVicroryPanel2;

        [Header("VictoryPanelMovement")]
        [SerializeField] private float _distance;
        public float MovementTime = 2f;
        [SerializeField] private float _currentDistance;

        [Header("Other")]
        [SerializeField] private GameObject _plug;
        [SerializeField] private Timer _timer;
        [SerializeField] private NewInLine _newInLine;
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;

        [Header("Animator")]
        [SerializeField] private Animator _firstPanelAnimator;
        [SerializeField] private Animator _secondPanelAnimator;
        [SerializeField] private Animator _thirdPanelAnimator;

        private void Start()
        {
            ChekContinuation();
        }
        public void CheckVictory()
        {
            var gameData = _saveManagerGameScene.GameData;

            bool first;
            bool second;
            bool third;

            if (_firstCompositionLeft.text == _firstCompositionRight.text)
            {
                if (!_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _firstPanelAnimator.Play($"Connecting" +
                        $"{_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }
                first = true;
            }
            else
            {
                if (_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _firstPanelAnimator.Play($"Unconnecting" +
                        $"{_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                }
                first = false;
            }
            if (_secondCompositionLeft.text == _secondCompositionRight.text)
            {
                if (!_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _secondPanelAnimator.Play($"Connecting" +
                        $"{_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }
                second = true;
            }
            else
            {
                if (_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _secondPanelAnimator.Play($"Unconnecting" +
                        $"{_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                }
                second = false;
            }
            if (_thirdCompositionLeft.text == _thirdCompositionRight.text)
            {
                if (!_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _thirdPanelAnimator.Play($"Connecting" +
                        $"{_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = true;
                }
                third = true;
            }
            else
            {
                if (_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _thirdPanelAnimator.Play($"Unconnecting" +
                        $"{_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                }
                third = false;
            }

            if (first && second && third)
            {
                _timer.StopTimer();

                if (_newInLine.LastTouched != null)
                {
                    if (_newInLine.LastTouched.GetComponent<TextMeshProUGUI>().text != "")
                    {
                        _newInLine.LastTouched.GetComponent<AddBeginDrag>().BeginDrag = false;
                        _newInLine.RecalculationOnEndDrag(_newInLine.LastTouched,
                            _newInLine.LastTouched.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                        _newInLine.CollisionWithSomethingOtherThanBack = false;
                    }
                }

                _plug.SetActive(true);

                if (!SecondaryInformation.IsContinuation)
                {
                    gameData.LastGameScore++;
                }

                switch(gameData.SelectedDifficulty)
                {
                    case 1:
                        if (gameData.EasyScore < gameData.LastGameScore)
                        {
                            gameData.EasyScore = gameData.LastGameScore;
                        }
                        break;
                    case 2:
                        if (gameData.MediumScore < gameData.LastGameScore)
                        {
                            gameData.MediumScore = gameData.LastGameScore;
                        }
                        break;
                    case 3:
                        if (gameData.MediumScore < gameData.LastGameScore)
                        {
                            gameData.HardScore = gameData.LastGameScore;
                        }
                        break;
                }

                _scoreText.SetText($"Score {gameData.LastGameScore}");
                StartCoroutine(VictoryPanelMovement());

                gameData.LevelIsOver = true;

                if (!SecondaryInformation.IsContinuation)
                {
                    _timer.AddTime();
                }

                _timer.SetTimeOnTimer();
                _saveManagerGameScene.Save();
            }
        }

        private IEnumerator VictoryPanelMovement()
        {
            _currentDistance = 0f;
            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;
                _victoryPanel.anchoredPosition += new Vector2(0, _distance / MovementTime * Time.deltaTime);

                yield return null;
            }

            _victoryPanel.anchoredPosition = Vector2.zero;

            //рекламка
        }

        private void ChekContinuation()
        {
            if(SecondaryInformation.IsContinuation && _saveManagerGameScene.GameData.LevelIsOver)
            {
                _victoryPanel.anchoredPosition = Vector2.zero;
                _plug.SetActive(true);
            }
            else
            {
                _victoryPanel.anchoredPosition = new Vector2(0,
                -Screen.height * (_victoryPanel.anchorMax.y - _victoryPanel.anchorMin.y));
                _distance = -_victoryPanel.anchoredPosition.y;
            }
        }
    }
}