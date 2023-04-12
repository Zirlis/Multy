using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class AbandonButton : MonoBehaviour
    {
        [SerializeField] private SaveManagerGameScene _saveManagerGameScene;
        private SceneTransition _sceneTransition;
        void Start()
        {
            _sceneTransition = new SceneTransition();
            GetComponent<Button>().onClick.AddListener(Abandon);
        }

        private void Abandon()
        {
            _saveManagerGameScene.Save();
            _sceneTransition.GoToMainScene();
        }
    }
}
