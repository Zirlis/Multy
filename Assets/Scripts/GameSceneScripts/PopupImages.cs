using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class PopupImages : MonoBehaviour
    {
        [SerializeField] private List<Image> _popupImages;
        [SerializeField] private List<Sprite> _popupSprites;

        private void Awake()
        {
            if (Random.Range(0, 100) < 95)
            {
                int spriteNumber = Random.Range(0, _popupSprites.Count);
                _popupImages[Random.Range(0, _popupImages.Count)].sprite = _popupSprites[spriteNumber];
                _popupSprites.RemoveAt(spriteNumber);
                if (Random.Range(0, 100) < 50)                
                    _popupImages[Random.Range(0, _popupImages.Count)].sprite = _popupSprites[Random.Range(0, _popupSprites.Count)];                
            }
        }

    }
}