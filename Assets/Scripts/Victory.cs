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

        private void Start()
        {
            ChekContinuation();
        }
        public void CheckVictory()
        {
            bool first;
            bool second;
            bool third;

            if (_firstCompositionLeft.text == _firstCompositionRight.text)
            {
                //анимация первой панели
                first = true;
            }
            else
            {
                //анимация первой панели
                first = false;
            }
            if (_secondCompositionLeft.text == _secondCompositionRight.text)
            {
                //анимация второй панели
                second = true;
            }
            else
            {
                //анимация второй панели
                second = false;
            }
            if (_thirdCompositionLeft.text == _thirdCompositionRight.text)
            {
                //анимация третьей панели
                third = true;
            }
            else
            {
                //анимация третьей панели
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
                _saveManagerGameScene.GameData.LastGameScore++;
                _scoreText.SetText($"Score {_saveManagerGameScene.GameData.LastGameScore}");
                StartCoroutine(VictoryPanelMovement());
                
                _saveManagerGameScene.GameData.LevelIsOver = true;
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