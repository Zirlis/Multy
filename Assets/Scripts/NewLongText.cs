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
            "I hope you like it",
            "Very very very very very very very very very very very very very long and very very very very very very very very boring text",
            "I know it's hard to believe, but I don't know how to draw",
            "('.' )/",
            "(^.^)/",
            "(>_<)",
            "Platypuses can detect weak electric fields that occur, for example, when the muscles of crustaceans contract",
            "Adult male echidnas and platypuses have a small spur on their hind limbs. However, echidna spurs are not associated with venom glands",
            "Have fun",
            "Have fun",
            "What could be better than a good landscape?",
            "If the bathroom is clogged, it is better to remove the siphon and clean it, rather than pour chemicals into the pipes",
            "Do you like coffee? I absolutely do not understand this",
            "If a giraffe wore a scarf, what would it look like?",
            "What do you want?",
            "Are you having a good time?",
            "It turns out that not everyone can read the time by the arrows. Have you encountered this?",
            "What kind of music do you like?",
            "Do you dream often? They've been making me uncomfortable lately",
            "What is generally accepted to write in such places?",
            "Why do you need a small pocket on jeans?",
            "I think... Okay, forget it",
            "How do you like my game?",
            "Will we live to immortality?",
            "",
            "",
            "I love milk",
            "Be careful",
            "Watch yourself, be careful",
            "Drink water",
            "Drink water",
            "It's not that simple",
            "..."
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