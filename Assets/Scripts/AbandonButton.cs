using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class AbandonButton : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;
        [SerializeField] private List<Sprite> _goBackButtonIcons;

        [SerializeField] private LoadingPanelAnimation _loadingPanelAnimation;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(Abandon);

            int _iconIndex = Random.Range(0, _goBackButtonIcons.Count);
            gameObject.GetComponent<Image>().sprite = _goBackButtonIcons[_iconIndex];
        }

        private void Abandon()
        {

            _saveManagerGameScene.Save();
            _loadingPanelAnimation.StartAnimation("MainScene");
        }
    }
}
