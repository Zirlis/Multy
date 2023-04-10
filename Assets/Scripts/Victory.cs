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

        private void Start()
        {
            _victoryPanel.anchoredPosition = new Vector2(0,
                -Screen.height * (_victoryPanel.anchorMax.y - _victoryPanel.anchorMin.y));
            _distance = -_victoryPanel.anchoredPosition.y;
        }
        public void CheckVictory(GameObject multiplier)
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
                //остановить таймер
                //сейв

                multiplier.GetComponent<AddBeginDrag>().BeginDrag = false;
                multiplier.GetComponent<TextMeshProUGUI>().SetText("");
                multiplier.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                _plug.SetActive(true);
                StartCoroutine(VictoryPanelMovement());
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
    }
}