using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class MainMenu : MonoBehaviour
    {
        [Header("ButtonsChoiceOfDifficulty")]
        [SerializeField] private Button _hardButton;
        [SerializeField] private Button _mediumButton;
        [SerializeField] private Button _easyButton;
        [SerializeField] private SaveManager _saveManager;

        private SceneTransition _sceneTransition;
        private GameData _gameData;
        private Storage _storage;

        private void Awake()
        {
            _storage = new Storage();
            _gameData = (GameData)_storage.Load(new GameData());

            _sceneTransition = new SceneTransition();
            _hardButton.onClick.AddListener(HardDifficulty);
            _mediumButton.onClick.AddListener(MediumDifficulty);
            _easyButton.onClick.AddListener(EasyDifficulty);
        }

        private void HardDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 3;
            _saveManager.Save();
            _sceneTransition.GoToGameScene();            
        }

        private void MediumDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 2;
            _saveManager.Save();
            _sceneTransition.GoToGameScene();
        }

        private void EasyDifficulty()
        {
            _saveManager.GameData.SelectedDifficulty = 1;
            _saveManager.Save();
            _sceneTransition.GoToGameScene();
        }
    }
}
