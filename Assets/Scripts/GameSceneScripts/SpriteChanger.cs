using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class SpriteChanger : MonoBehaviour
    {
        [SerializeField] private List<Sprite> Sprites;
        private void Start()
        {
            int selectedSprite = Random.Range(0, Sprites.Count);
            gameObject.GetComponent<Image>().sprite = Sprites[selectedSprite];
        }
    }
}