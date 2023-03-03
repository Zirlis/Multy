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

        private void Awake()
        {
            _sceneTransition = new SceneTransition();
            _hardButton.onClick.AddListener(StartGame);
        }



        private void StartGame()
        {
            _sceneTransition.GameScene();            
        }
    }
}
