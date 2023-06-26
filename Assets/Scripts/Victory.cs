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
        [SerializeField] private AudioPlayer _penWriting;
        [SerializeField] private AudioPlayer _pageTurning;
        [SerializeField] private Ads _ads;

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

            int numberOfSolvedLines = 0;

            if (_firstCompositionLeft.text == _firstCompositionRight.text)
            {
                if (!_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _firstPanelAnimator.Play($"Connecting" +
                        $"{_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = true;
                    _penWriting.PlayAudio();
                }
                first = true;
                numberOfSolvedLines++;
            }
            else
            {
                if (_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _firstPanelAnimator.Play($"Unconnecting" +
                        $"{_firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _firstCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                    _penWriting.PlayAudio();
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
                    _penWriting.PlayAudio();
                }
                second = true;
                numberOfSolvedLines++;
            }
            else
            {
                if (_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _secondPanelAnimator.Play($"Unconnecting" +
                        $"{_secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _secondCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                    _penWriting.PlayAudio();
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
                    _penWriting.PlayAudio();
                }
                third = true;
                numberOfSolvedLines++;
            }
            else
            {
                if (_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    _thirdPanelAnimator.Play($"Unconnecting" +
                        $"{_thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    _thirdCompositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                    _penWriting.PlayAudio();
                }
                third = false;
            }

            if (numberOfSolvedLines > 0)
            {
                if(gameData.LastGameScore % (3 * gameData.SelectedDifficulty) == 0 && !SecondaryInformation.IsContinuation)
                {
                    gameData.LastGameScore += gameData.SelectedDifficulty;
                    _timer.AddTimeOnLine();

                    switch (gameData.SelectedDifficulty)
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
                }

                if(numberOfSolvedLines > 1)
                {
                    if (gameData.LastGameScore % (3 * gameData.SelectedDifficulty) == gameData.SelectedDifficulty && !SecondaryInformation.IsContinuation)
                    {
                        gameData.LastGameScore += gameData.SelectedDifficulty;
                        _timer.AddTimeOnLine();

                        switch (gameData.SelectedDifficulty)
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
                    }
                }
            }

            if (first && second && third)
            {
                _timer.StopTimer();

                if (_newInLine.LastTouched != null)
                {
                    var TMPOfLastTouched = _newInLine.LastTouched.GetComponent<TextMeshProUGUI>();

                    if (TMPOfLastTouched.text != "")
                    {
                        TMPOfLastTouched.SetText("");
                        _newInLine.LastTouched.GetComponent<AddBeginDrag>().BeginDrag = false;
                        _newInLine.RecalculationOnEndDrag(_newInLine.LastTouched,
                            _newInLine.LastTouched.GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                        _newInLine.CollisionWithSomethingOtherThanBack = false;
                    }
                }

                _plug.SetActive(true);

                if (!SecondaryInformation.IsContinuation)
                {
                    gameData.LastGameScore += gameData.SelectedDifficulty;
                }

                switch (gameData.SelectedDifficulty)
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
                    _timer.AddTimeOnLevel();
                }

                _timer.SetTimeOnTimer();
                _saveManagerGameScene.Save();
            }
        }

        private IEnumerator VictoryPanelMovement()
        {
            _pageTurning.PlayAudio();
            _currentDistance = 0f;
            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;
                _victoryPanel.anchoredPosition += new Vector2(0, _distance / MovementTime * Time.deltaTime);

                yield return null;
            }

            _victoryPanel.anchoredPosition = Vector2.zero;

            if(SecondaryInformation.TimeAfterAd > 480)
            {
                _ads.ShowAd();
                SecondaryInformation.TimeAfterAd = 0;
            }
        }

        private void ChekContinuation()
        {
            if(SecondaryInformation.IsContinuation && _saveManagerGameScene.GameData.LevelIsOver)
            {
                _victoryPanel.anchoredPosition = Vector2.zero;
                _plug.SetActive(true);

                _timer.TimeOnTimer--;
                _timer.SetTimeOnTimer();
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