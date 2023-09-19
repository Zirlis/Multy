using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class Defeat : MonoBehaviour
    {
        [Header("LossPanelMovement")]
        [SerializeField] private float _distance;
        public float MovementTime = 2f;
        [SerializeField] private float _currentDistance;

        [Header("Scripts")]
        [SerializeField] private NewInLine _newInLine;
        [SerializeField] private SaveManagerGameScene _saveManager;
        [SerializeField] private Timer _timer;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private Ads _ads;

        [Header("GamePanels")]
        [SerializeField] private Transform _firstPanel;
        [SerializeField] private Transform _secondPanel;
        [SerializeField] private Transform _thirdPanel;
        [SerializeField] private Transform _reserve;

        [Header("Other")]
        [SerializeField] private GameObject _plug;
        [SerializeField] private RectTransform _lossPanel;        
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private AudioPlayer _pageTurning;

        private void Start()
        {
            _lossPanel.anchoredPosition = new Vector2(0, -Screen.height * (_lossPanel.anchorMax.y - _lossPanel.anchorMin.y));
            _distance = -_lossPanel.anchoredPosition.y;
        }

        public void TimeIsEnd()
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

            _saveManager.GameData.GameIsOver = true;

            _timer.StopTimer();
            _plug.SetActive(true);
            _scoreText.SetText($"Score {_saveManager.GameData.LastGameScore}");
            StartCoroutine(LossPanelMovement());
            ReturnOfIntersections(_firstPanel, _levelGenerator.FirstPanelMultipliers);
            ReturnOfIntersections(_secondPanel, _levelGenerator.SecondPanelMultipliers);
            ReturnOfIntersections(_thirdPanel, _levelGenerator.ThirdPanelMultipliers);
            ReturnOfIntersectionsOnReserve();

            _saveManager.Save();
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
                if (text != "")
                    localMultipliers.Add(Int32.Parse(text));
                else
                    break;
            }

            for (int i = 0; i < 6; i++)
            {
                if (i < startPanelMultipliers.Count)
                {
                    panelTransform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(startPanelMultipliers[i].ToString());

                    if (i != 0)
                        panelTransform.GetChild(i + 5).gameObject.SetActive(true);

                    foreach (int multiplier in localMultipliers)
                    {
                        if (multiplier == startPanelMultipliers[i])
                        {
                            localMultipliers.Remove(multiplier);
                            localMultipliers.Add(0);
                            break;
                        }
                    }
                }
                else
                {
                    panelTransform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

                    if (i != 0)
                        panelTransform.GetChild(i + 5).gameObject.SetActive(false);
                }
            }

            var leftCompositionTMPro = panelTransform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>();
            var rightCompositionTMPro = panelTransform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>();

            leftCompositionTMPro.SetText(rightCompositionTMPro.text);
        }
        private void ReturnOfIntersectionsOnReserve()
        {
            List<int> startPanelMultipliers = _levelGenerator.ReservePanalMultipliers;

            for (int i = 0; i < _reserve.childCount; i++)
            {
                if (i < startPanelMultipliers.Count)
                    _reserve.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText(startPanelMultipliers[i].ToString());
                else
                    _reserve.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
            }
        }
    }
}