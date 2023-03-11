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
            _gameData.SelectedDifficulty = 3;
            _sceneTransition.GameScene();            
        }

        private void MediumDifficulty()
        {
            _gameData.SelectedDifficulty = 2;
            _sceneTransition.GameScene();
        }

        private void EasyDifficulty()
        {
            _gameData.SelectedDifficulty = 1;
            _sceneTransition.GameScene();
        }
    }
}
