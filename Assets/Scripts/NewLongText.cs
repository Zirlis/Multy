using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class NewLongText : MonoBehaviour
    {
        private TextMeshProUGUI _longText;
        private string[] _texts = 
            {"0", "1", "2"};

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