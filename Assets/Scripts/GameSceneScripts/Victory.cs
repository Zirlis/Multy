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

        private int numberOfSolvedLines;
        private GameData _gameData;

        private void Start()
        {
            ChekContinuation();
            _gameData = _saveManagerGameScene.GameData;
        }

        private void ChekContinuation()
        {
            if (SecondaryInformation.IsContinuation && _saveManagerGameScene.GameData.LevelIsOver)
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

        public void CheckVictory()
        {
            numberOfSolvedLines = 0;

            PanelAnimation(_firstCompositionLeft, _firstCompositionRight, _firstPanelAnimator);
            PanelAnimation(_secondCompositionLeft, _secondCompositionRight, _secondPanelAnimator);
            PanelAnimation(_thirdCompositionLeft, _thirdCompositionRight, _thirdPanelAnimator);
            

            if (numberOfSolvedLines > 0)
                ScoringPoint(0);

            if (numberOfSolvedLines > 1)
                ScoringPoint(_gameData.SelectedDifficulty);

            if (numberOfSolvedLines == 3)
            {
                _timer.StopTimer();

                if (_newInLine.LastTouched != null)
                    CheckLastTouch();                

                _plug.SetActive(true);

                if (!SecondaryInformation.IsContinuation)                
                    _gameData.LastGameScore += _gameData.SelectedDifficulty;
                
                UpdatingTheRecord();

                _scoreText.SetText($"Score {_gameData.LastGameScore}");
                StartCoroutine(VictoryPanelMovement());

                _gameData.LevelIsOver = true;

                if (!SecondaryInformation.IsContinuation)                
                    _timer.AddTimeOnLevel();
                

                _timer.SetTimeOnTimer();
                _saveManagerGameScene.Save();
            }
        }

        private void PanelAnimation(TextMeshProUGUI compositionLeft, TextMeshProUGUI compositionRight, Animator panelAnimator)
        {
            if (compositionLeft.text == compositionRight.text)
            {
                if (!compositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    panelAnimator.Play($"Connecting" +
                        $"{compositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    compositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = true;
                    _penWriting.PlayAudio();
                }
                numberOfSolvedLines++;
            }
            else
            {
                if (compositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed)
                {
                    panelAnimator.Play($"Unconnecting" +
                        $"{compositionLeft.transform.parent.GetComponent<PanelChangeImage>().PanelAnimationVersion}");
                    compositionLeft.transform.parent.GetComponent<PanelChangeImage>().IsConnecteed = false;
                    _penWriting.PlayAudio();
                }
            }
        }

        private void ScoringPoint(int remains)
        {
            if (_gameData.LastGameScore % (3 * _gameData.SelectedDifficulty) == remains && !SecondaryInformation.IsContinuation)
            {
                _gameData.LastGameScore += _gameData.SelectedDifficulty;
                _timer.AddTimeOnLine();
                UpdatingTheRecord();
            }
        }

        private void UpdatingTheRecord()
        {
            switch (_gameData.SelectedDifficulty)
            {
                case 1:
                    if (_gameData.EasyScore < _gameData.LastGameScore)
                        _gameData.EasyScore = _gameData.LastGameScore;

                    break;
                case 2:
                    if (_gameData.MediumScore < _gameData.LastGameScore)
                        _gameData.MediumScore = _gameData.LastGameScore;

                    break;
                case 3:
                    if (_gameData.HardScore < _gameData.LastGameScore)
                        _gameData.HardScore = _gameData.LastGameScore;

                    break;
            }
        }

        private void CheckLastTouch()
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
    }
}