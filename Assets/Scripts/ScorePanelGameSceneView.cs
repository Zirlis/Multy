using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class ScorePanelGameSceneView : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _scorePanelIcons;
        [SerializeField] private List<Color> _colors;
        [SerializeField] private SaveManager _saveManager;

        private void Start()
        {
            var image = gameObject.GetComponent<Image>();
            image.sprite = _scorePanelIcons[Random.Range(0, _scorePanelIcons.Count)];
            image.color = _colors[_saveManager.GameData.SelectedDifficulty - 1];
        }
    }
}
