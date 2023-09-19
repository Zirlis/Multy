using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class ResumeButton : MonoBehaviour
    {
        [SerializeField] private Sprite[] _resumeButtonSprites = new Sprite[5];

        private void Start()
        {
            GetComponent<Image>().sprite = _resumeButtonSprites[Random.Range(0, _resumeButtonSprites.Length)];
        }
    }
}