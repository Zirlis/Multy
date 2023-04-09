using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Multipliers
{
    public class NextLevel : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject _firstPlane;
        [SerializeField] private GameObject _secondPlane;
        [SerializeField] private GameObject _thirdPlane;
        [SerializeField] private GameObject _reserve;

        [Header("Other")]
        [SerializeField] private GameObject _plug;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private RectTransform _victoryPanel;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Invoke);
        }

        private void Invoke()
        {
            //включить анимацию

            ClearLine(_firstPlane);
            ClearLine(_secondPlane);
            ClearLine(_thirdPlane);
            ClearLine(_reserve);
            _levelGenerator.NewLevel();

            //выключить анимацию

            _plug.SetActive(false);
            _victoryPanel.anchoredPosition = new Vector2(0,
                -Screen.height * (_victoryPanel.anchorMax.y - _victoryPanel.anchorMin.y));

            //возобновить таймер
        }

        private void ClearLine(GameObject plane)
        {
            var transform = plane.transform;

            if (plane.name == "Reserve")
            {                
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                }

                for (int i = 6; i < 11; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
                transform.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().SetText("");
            }
        }
    }
}