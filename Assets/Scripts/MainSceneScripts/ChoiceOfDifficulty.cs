using UnityEngine;
using UnityEngine.UI;
using System;

namespace Multipliers
{
    public class ChoiceOfDifficulty : MonoBehaviour
    {
        [SerializeField] private SaveManager _saveManager;
        [SerializeField] private LoadingPanelAnimation _loadingPanelAnimation;
        [SerializeField] private MusicVolumeDown _musicVolumeDown;

        [SerializeField] private int difficulty;

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SelectDifficulty);
        }

        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(SelectDifficulty);
        }

        private void SelectDifficulty()
        {
            if (difficulty == 0)            
                SecondaryInformation.IsContinuation = true;            
            else
            {
                _saveManager.GameData.SelectedDifficulty = difficulty;
                SecondaryInformation.IsContinuation = false;
            }

            _saveManager.Save();
            _loadingPanelAnimation.StartAnimation("GameScene");
            _musicVolumeDown.StartVolumeDown();
        }
    }
}
