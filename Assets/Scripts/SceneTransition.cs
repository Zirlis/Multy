using UnityEngine.SceneManagement;

namespace Multipliers
{
    public class SceneTransition 
    {
        public void GoToGameScene()
        {
            //анимация
            //коенц анимации

            SceneManager.LoadScene("GameScene");
        }

        public void GoToMainScene()
        {
            //анимация
            //коенц анимации

            SceneManager.LoadScene("MainScene");
        }
    }
}
