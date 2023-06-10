using UnityEngine;

namespace Multipliers
{
    public class BackgroundRotation : MonoBehaviour
    {
        void Start()
        {
            var rectTransform = GetComponent<RectTransform>();
            float zRotation = Random.Range(-1f, 1f);
            float rndXPosition = Random.Range(-60f, 60f);
            float rndYPosition = Random.Range(-30f, 30f);

            rectTransform.Rotate(0, 0, zRotation);
            rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(rndXPosition, rndYPosition);
        }
    }
}