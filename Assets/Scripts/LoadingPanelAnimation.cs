using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Multipliers
{
    public class LoadingPanelAnimation : MonoBehaviour
    {
        private RectTransform _recTransform;

        [SerializeField] private float _distance;
        private float _centerPosition = 0f;
        public float MovementTime = 1f;
        [SerializeField] private float _currentDistance;
        [SerializeField] private AudioPlayer _pageTurning;
        [SerializeField] private AudioSource _music;

        private void Start()
        {
            _recTransform = gameObject.GetComponent<RectTransform>();
            _distance = Screen.width * 2;
            
            _recTransform.localScale = new Vector2(2, 2);

            if(SecondaryInformation.LoadingAnimationWasStarted)
            {
                FinishAnimation();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void FinishAnimation()
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadingPanelFinishMovement());
        }

        public void StartAnimation(string sceneName)
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadingPanelStartMovement(sceneName));
            _pageTurning.PlayAudio();
        }

        private IEnumerator LoadingPanelFinishMovement()
        {
            _recTransform.anchoredPosition = Vector3.zero;

            _currentDistance = _recTransform.anchoredPosition.x;
            while (_currentDistance > -_distance)
            {
                _currentDistance -= _distance / MovementTime * Time.deltaTime;
                _recTransform.anchoredPosition -= new Vector2(_distance / MovementTime * Time.deltaTime, 0);

                yield return null;
            }

            gameObject.SetActive(false);
            SecondaryInformation.LoadingAnimationWasStarted = false;
            //рекламка
        }

        private IEnumerator LoadingPanelStartMovement(string sceneName)
        {
            _recTransform.anchoredPosition = new Vector2(_distance, 0);

            _currentDistance = _recTransform.anchoredPosition.x;
            while (_currentDistance > _centerPosition)
            {
                _currentDistance -= _distance / MovementTime * Time.deltaTime;
                _recTransform.anchoredPosition -= new Vector2(_distance / MovementTime * Time.deltaTime, 0);

                yield return null;
            }

            SecondaryInformation.LoadingAnimationWasStarted = true;
            SceneManager.LoadScene(sceneName);
            //рекламка
        }

    }
}