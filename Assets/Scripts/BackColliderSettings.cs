using UnityEngine;

namespace Multipliers
{
    public class BackColliderSettings : MonoBehaviour
    {
        private void Start()
        {
            var rectTransform = GetComponent<RectTransform>();
            var width = Screen.width * (rectTransform.anchorMax.x - rectTransform.anchorMin.x);
            var height = Screen.height * (rectTransform.anchorMax.y - rectTransform.anchorMin.y);
            GetComponent<BoxCollider2D>().size = new Vector2(width * 10, height * 10);
        }
    }
}