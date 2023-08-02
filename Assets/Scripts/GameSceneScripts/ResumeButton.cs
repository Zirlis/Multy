using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class ResumeButton : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _resumeButtonSprites;

        private void Start()
        {
            GetComponent<Image>().sprite = _resumeButtonSprites[Random.Range(0, _resumeButtonSprites.Count)];
        }
    }
}