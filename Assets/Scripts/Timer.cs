using System.Collections;
using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class Timer : MonoBehaviour
    {
        [Header("Time")]
        private TextMeshProUGUI _timer;
        public float TimeOnTimer = 100;
        private bool _stopTimer;

        [Header("Other")]
        [SerializeField] private GameObject _plug;
        [SerializeField] private RectTransform _lossPanel;

        [Header("LossPanelMovement")]
        [SerializeField] private float _distance;
        public float MovementTime = 2f;
        [SerializeField] private float _currentDistance;

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

        private IEnumerator TimeIsTicking()
        {
            while(!_stopTimer)
            {
                if (TimeOnTimer > 0)
                {
                    TimeOnTimer -= Time.deltaTime;
                    _timer.SetText($"{(int)TimeOnTimer}");
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
            //сейв

            _plug.SetActive(true);

            StartCoroutine(LossPanelMovement());

            //вернуть множители с расцветкой зелёный/красный
        }

        private IEnumerator LossPanelMovement()
        {
            _currentDistance = 0f;
            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;
                _lossPanel.anchoredPosition += new Vector2(0, _distance / MovementTime * Time.deltaTime);

                yield return null;
            }

            _lossPanel.anchoredPosition = Vector2.zero;

            //рекламка
        }
    }
}