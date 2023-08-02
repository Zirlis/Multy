using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class Timer : MonoBehaviour
    {
        [Header("Time")]
        private TextMeshProUGUI _timer;
        public float TimeOnTimer = 65f;
        [SerializeField] private float TimeOnLevel = 25f;
        [SerializeField] private float TimeOnLine = 10f;
        private bool _stopTimer;

        [Header("Other")]
        [SerializeField] private GameObject _plug;
        [SerializeField] private RectTransform _lossPanel;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private NewInLine _newInLine;
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private AudioPlayer _pageTurning;
        [SerializeField] private Ads _ads;

        [Header("LossPanelMovement")]
        [SerializeField] private float _distance;
        public float MovementTime = 2f;
        [SerializeField] private float _currentDistance;

        [Header("GamePanels")]
        [SerializeField] private Transform _firstPanel;
        [SerializeField] private Transform _secondPanel;
        [SerializeField] private Transform _thirdPanel;
        [SerializeField] private Transform _reserve;


        private void Start()
        {
            _lossPanel.anchoredPosition = new Vector2(0,
                -Screen.height * (_lossPanel.anchorMax.y - _lossPanel.anchorMin.y));
            _distance = -_lossPanel.anchoredPosition.y;

            _timer = GetComponent<TextMeshProUGUI>();
            StartTimer();
        }

        public void StartTimer()
        {
            _stopTimer = false;
            StartCoroutine(TimeIsTicking());
        }
        public void StopTimer()
        {
            _stopTimer = true;
        }

        public void AddTimeOnLevel()
        {
            TimeOnTimer += TimeOnLevel;
        }

        public void AddTimeOnLine()
        {
            TimeOnTimer += TimeOnLine;
        }

        public void SetTimeOnTimer()
        {
            _timer.SetText($"{(int)TimeOnTimer}");
        }

        private IEnumerator TimeIsTicking()
        {
            while(!_stopTimer)
            {
                if (TimeOnTimer > 0)
                {
                    TimeOnTimer -= Time.deltaTime;
                    SetTimeOnTimer();
                }
                else
                {
                    TimeOnTimer = 0;
                    TimeIsEnd();
                }
                yield return null;
            }
        }

        private void TimeIsEnd()
        {
            if (_newInLine.LastTouched != null)
            {
                if (_newInLine.LastTouched.GetComponent<TextMeshProUGUI>().text != "")
                {
                    _newInLine.LastTouched.GetComponent<AddBeginDrag>().BeginDrag = false;
                    _newInLine.RecalculationOnEndDrag(_newInLine.LastTouched, _newInLine.LastTouched.
                        GetComponent<AddBeginDrag>().Original.transform.parent.gameObject);
                    _newInLine.CollisionWithSomethingOtherThanBack = false;
                }
            }

            _saveManagerGameScene.GameData.GameIsOver = true;

            StopTimer();
            _plug.SetActive(true);
            _scoreText.SetText($"Score {_saveManagerGameScene.GameData.LastGameScore}");
            StartCoroutine(LossPanelMovement());
            ReturnOfIntersections(_firstPanel, _levelGenerator.FirstPanelMultipliers);
            ReturnOfIntersections(_secondPanel, _levelGenerator.SecondPanelMultipliers);
            ReturnOfIntersections(_thirdPanel, _levelGenerator.ThirdPanelMultipliers);
            ReturnOfIntersectionsOnReserve();

            _saveManagerGameScene.Save();
        }

        private IEnumerator LossPanelMovement()
        {
            _pageTurning.PlayAudio();
            _currentDistance = 0f;
            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;
                _lossPanel.anchoredPosition += new Vector2(0, _distance / MovementTime * Time.deltaTime);

                yield return null;
            }

            _lossPanel.anchoredPosition = Vector2.zero;

            if (SecondaryInformation.TimeAfterAd > 300)
            {
                _ads.ShowAd();
                SecondaryInformation.TimeAfterAd = 0;
            }
        }

        private void ReturnOfIntersections(Transform panelTransform, List<int> startPanelMultipliers)
        {
            List<int> localMultipliers = new List<int>();

            for (int i = 0; i < 6; i++)
            {
                var text = panelTransform.GetChild(i).GetComponent<TextMeshProUGUI>().text;
                if(text != "")
                {
                    localMultipliers.Add(Int32.Parse(text));
                }
                else
                {
                    break;
                }    
            }

            for (int i = 0; i < 6; i++)
            {
                if (i < startPanelMultipliers.Count)
                {
                    panelTransform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(startPanelMultipliers[i].ToString());

                    if(i != 0)
                    {
                        panelTransform.GetChild(i + 5).gameObject.SetActive(true);
                    }

                    foreach (int multiplier in localMultipliers)
                    {
                        if(multiplier == startPanelMultipliers[i])
                        {
                            localMultipliers.Remove(multiplier);
                            localMultipliers.Add(0);
                            //делает зелёным или это лишнее
                            break;
                        }
                        else
                        {
                            //делает красным
                        }
                    }
                }
                else
                {
                    panelTransform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText("");

                    if (i != 0)
                    {
                        panelTransform.GetChild(i + 5).gameObject.SetActive(false);
                    }
                }
            }

            var leftCompositionTMPro = panelTransform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>();
            var rightCompositionTMPro = panelTransform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>();
            if (rightCompositionTMPro.text != leftCompositionTMPro.text)
            {
                //leftCompositionTMPro помечается красным
            }
            leftCompositionTMPro.SetText(rightCompositionTMPro.text);
        }
        private void ReturnOfIntersectionsOnReserve()
        {
            List<int> startPanelMultipliers = _levelGenerator.ReserveMultipliers;

            for (int i = 0; i < _reserve.childCount; i++)
            {
                if (i < startPanelMultipliers.Count)
                {
                    _reserve.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().
                        SetText(startPanelMultipliers[i].ToString());                    
                }
                else
                {
                    _reserve.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                }
            }
        }
    }
}