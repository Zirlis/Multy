using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class UnpauseButton : MonoBehaviour
    {
        [SerializeField] private AudioPlayer _pageTurning;
        [SerializeField] private Button _unpauseButton;
        [SerializeField] private GameObject _popupMenu;
        [SerializeField] private Timer _timer;
        [SerializeField] private List<Sprite> _unpauseButtonIcons;

        private void Awake()
        {
            _unpauseButton.onClick.AddListener(UnPause);

            int _iconIndex = Random.Range(0, _unpauseButtonIcons.Count);
            gameObject.GetComponent<Image>().sprite = _unpauseButtonIcons[_iconIndex];
        }

        private void OnDestroy()
        {
            _unpauseButton.onClick.RemoveListener(UnPause);
        }

        private void UnPause()
        {
            _popupMenu.SetActive(false);
            _pageTurning.PlayAudio();

            _timer.StartTimer();
        }
    }
}