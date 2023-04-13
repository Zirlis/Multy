using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Multipliers
{
    public class MainMenu : MonoBehaviour
    {
        [Header("ButtonsChoiceOfDifficulty")]
        [SerializeField] private Button _hardButton;
        [SerializeField] private Button _mediumButton;
        [SerializeField] private Button _easyButton;
        [SerializeField] private SaveManager _saveManager;

        [Header("Other")]
        [SerializeField] private Button _resumeButton;


        private SceneTransition _sceneTransition;

        private void Awake()
        {
            _sceneTransition = new SceneTransition();
            _hardButton.onClick.AddListener(HardDifficulty);
            _mediumButton.onClick.AddListener(MediumDifficulty);
            _easyButton.onClick.AddListener(EasyDifficulty);
            _resumeButton.onClick.AddListener(ResumeGame);
        }

        private void HardDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 3;
            _saveManager.Save();
            SecondaryInformation.IsContinuation = false;
            _sceneTransition.GoToGameScene();            
        }

        private void MediumDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 2;
            _saveManager.Save();
            SecondaryInformation.IsContinuation = false;
            _sceneTransition.GoToGameScene();
        }

        private void EasyDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 1;
            _saveManager.Save();
            SecondaryInformation.IsContinuation = false;
            _sceneTransition.GoToGameScene();
        }

        private void ResumeGame()
        {
            SecondaryInformation.IsContinuation = true;
            _sceneTransition.GoToGameScene();
        }
    }
}
