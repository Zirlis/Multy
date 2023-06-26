using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

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
        [SerializeField] private Timer _timer;
        [SerializeField] private List<Sprite> _nextLevelButtonIcons;
        [SerializeField] private AudioPlayer _pageTurning;

        [Header("LoadingPanel")]
        [SerializeField] private GameObject _loadingPanel;
        private RectTransform _recTransform;
        [SerializeField] private float _distance;
        private float _centerPosition = 0f;
        public float MovementTime = 1f;
        [SerializeField] private float _currentDistance;

        private void Start()
        {
            _recTransform = _loadingPanel.GetComponent<RectTransform>();
            _distance = Screen.width * 2;

            GetComponent<Button>().onClick.AddListener(Invoke);

            int _iconIndex = Random.Range(0, _nextLevelButtonIcons.Count);
            gameObject.GetComponent<Image>().sprite = _nextLevelButtonIcons[_iconIndex];
        }

        private void Invoke()
        {
            StartCoroutine(PanelAnimation());
        }

        private IEnumerator PanelAnimation()
        {
            _loadingPanel.SetActive(true);
            _recTransform.anchoredPosition = new Vector2(_distance, 0);
            _pageTurning.PlayAudio();

            _currentDistance = _recTransform.anchoredPosition.x;
            while (_currentDistance > _centerPosition)
            {
                _currentDistance -= _distance / MovementTime * Time.deltaTime;
                _recTransform.anchoredPosition -= new Vector2(_distance / MovementTime * Time.deltaTime, 0);

                yield return null;
            }

            ClearAllLines();
            _levelGenerator.NewLevel();

            var firstPanelChangeImage = _firstPlane.GetComponent<PanelChangeImage>();
            _firstPlane.GetComponent<Animator>().Play($"Unconnected{firstPanelChangeImage.PanelAnimationVersion}");
            firstPanelChangeImage.IsConnecteed = false;

            var secondPanelChangeImage = _secondPlane.GetComponent<PanelChangeImage>();
            _secondPlane.GetComponent<Animator>().Play($"Unconnected{secondPanelChangeImage.PanelAnimationVersion}");
            secondPanelChangeImage.IsConnecteed = false;

            var thirdPanelChangeImage = _thirdPlane.GetComponent<PanelChangeImage>();
            _thirdPlane.GetComponent<Animator>().Play($"Unconnected{thirdPanelChangeImage.PanelAnimationVersion}");
            thirdPanelChangeImage.IsConnecteed = false;

            _victoryPanel.anchoredPosition = new Vector2(0,
                -Screen.height * (_victoryPanel.anchorMax.y - _victoryPanel.anchorMin.y));

            _recTransform.anchoredPosition = Vector3.zero;

            _currentDistance = _recTransform.anchoredPosition.x;
            while (_currentDistance > -_distance)
            {
                _currentDistance -= _distance / MovementTime * Time.deltaTime;
                _recTransform.anchoredPosition -= new Vector2(_distance / MovementTime * Time.deltaTime, 0);

                yield return null;
            }

            _loadingPanel.SetActive(false);

            _plug.SetActive(false);

            _timer.StartTimer();
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

        public void ClearAllLines()
        {
            ClearLine(_firstPlane);
            ClearLine(_secondPlane);
            ClearLine(_thirdPlane);
            ClearLine(_reserve);
        }
    }
}