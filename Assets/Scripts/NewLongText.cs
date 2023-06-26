using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class NewLongText : MonoBehaviour
    {
        private TextMeshProUGUI _longText;
        private string[] _texts = 
        {
            "Very very very very very very very very very very very very very long and very very very very very very very very boring text",
            "I know it's hard to believe, but I don't know how to draw",
            "('.' )/",
            "(^.^)/",
            "(>_<)"
        };

        void Start()
        {
            _longText = GetComponent<TextMeshProUGUI>();
            NewText();
            GetComponent<Button>().onClick.AddListener(NewText);
        }

        private void NewText()
        {
            int rand = Random.Range(0, _texts.Length);
            _longText.SetText(_texts[rand]);
        }
    }
}