using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Multipliers
{
    public class MainMenu : MonoBehaviour
    {
        [Header("ButtonsChoiceOfDifficulty")]
        [SerializeField] private Button _hardButton;
        [SerializeField] private List<Sprite> _hardButtonIcons;
        [SerializeField] private Button _mediumButton;
        [SerializeField] private List<Sprite> _mediumButtonIcons;
        [SerializeField] private Button _easyButton;
        [SerializeField] private List<Sprite> _easyButtonIcons;

        [Header("Other")]
        [SerializeField] private Button _resumeButton;
        [SerializeField] private SaveManager _saveManager;


        private SceneTransition _sceneTransition;

        private void Awake()
        {
            _sceneTransition = new SceneTransition();
            _hardButton.onClick.AddListener(HardDifficulty);
            _mediumButton.onClick.AddListener(MediumDifficulty);
            _easyButton.onClick.AddListener(EasyDifficulty);
            _resumeButton.onClick.AddListener(ResumeGame);

            _hardButton.gameObject.GetComponent<Image>().sprite = 
                _hardButtonIcons[Random.Range(0, _hardButtonIcons.Count)];
            _mediumButton.gameObject.GetComponent<Image>().sprite = 
                _mediumButtonIcons[Random.Range(0, _mediumButtonIcons.Count)];
            _easyButton.gameObject.GetComponent<Image>().sprite = 
                _easyButtonIcons[Random.Range(0, _easyButtonIcons.Count)];
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
