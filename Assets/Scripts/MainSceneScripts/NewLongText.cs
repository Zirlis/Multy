using TMPro;
using UnityEngine;

namespace Multipliers
{
    public class NewLongText : MonoBehaviour
    {
        private TextMeshProUGUI _longText;
        [SerializeField] private string[] _texts = new string[33];      

        void Start()
        {
            _longText = GetComponent<TextMeshProUGUI>();
            _longText.SetText(_texts[Random.Range(0, _texts.Length)]);
        }
    }
}