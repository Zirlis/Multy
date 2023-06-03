using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class PapersSpriteChanger : MonoBehaviour
    {
        [SerializeField] private PaperSpriteList _paperSpriteList;
        private void Start()
        {  
            var spriteList = _paperSpriteList.PaperSprites;
            int selectedSprite = Random.Range(0, spriteList.Count);
            gameObject.GetComponent<Image>().sprite = spriteList[selectedSprite];
            spriteList.RemoveAt(selectedSprite);
        }
    }
}