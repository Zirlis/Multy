using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class ImageChanger : MonoBehaviour
    {
        [Header("DifficultyButtons")]
        [SerializeField] private Button[] _difficultyButtons = new Button[4];
        [Space(10)]
        [SerializeField] private Sprite[] _resumeButtonImages = new Sprite[5];
        [SerializeField] private Sprite[] _easyButtonImages = new Sprite[3];
        [SerializeField] private Sprite[] _mediumButtonImages = new Sprite[3];
        [SerializeField] private Sprite[] _hardButtonImages = new Sprite[3];

        [Header("ScorePanel")]
        [SerializeField] private Image _scorePanel;
        [SerializeField] private Sprite[] _scorePanelImages = new Sprite[5];
        [SerializeField] private Color[] _colors = new Color[3];

        [Header("Other")]
        [SerializeField] private SaveManager _saveManager;


        private void Start()
        {
            _difficultyButtons[0].gameObject.GetComponent<Image>().sprite =
                _resumeButtonImages[Random.Range(0, _resumeButtonImages.Length)];
            _difficultyButtons[1].gameObject.GetComponent<Image>().sprite =
                _easyButtonImages[Random.Range(0, _easyButtonImages.Length)];
            _difficultyButtons[2].gameObject.GetComponent<Image>().sprite =
                _mediumButtonImages[Random.Range(0, _mediumButtonImages.Length)];
            _difficultyButtons[3].gameObject.GetComponent<Image>().sprite =
                _hardButtonImages[Random.Range(0, _hardButtonImages.Length)];

            _scorePanel.sprite = _scorePanelImages[Random.Range(0, _scorePanelImages.Length)];
            if(_saveManager.GameData.SelectedDifficulty > 0)
                _scorePanel.color = _colors[_saveManager.GameData.SelectedDifficulty - 1];
        }
    }
}
