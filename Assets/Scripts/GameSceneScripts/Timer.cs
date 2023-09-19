using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class Timer : MonoBehaviour
    {
        private TextMeshProUGUI _timer;
        public float TimeOnTimer = 65f;
        [SerializeField] private float TimeOnLevel = 25f;
        [SerializeField] private float TimeOnLine = 10f;
        private bool _stopTimer;
        [SerializeField] private Defeat _defeat;

        private void Start()
        {
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
                    _defeat.TimeIsEnd();
                }
                yield return null;
            }
        }        
    }
}