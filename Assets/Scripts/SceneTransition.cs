using UnityEngine.SceneManagement;

namespace Multipliers
{
    public class SceneTransition 
    {
        public void GoToGameScene()
        {
            //��������
            //����� ��������

            SceneManager.LoadScene("GameScene");
        }

        public void GoToMainScene()
        {
            //��������
            //����� ��������

            SceneManager.LoadScene("MainScene");
        }
    }
}
