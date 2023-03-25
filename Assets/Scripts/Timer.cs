using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class Timer : MonoBehaviour
    {
        private TextMeshProUGUI _timer;
        public float _time = 100;

        private void Start()
        {
            _timer = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                _timer.SetText($"{(int)_time}");
            }
            else
            {
                _time = 0;
                //gg
            }            
        }
    }
}