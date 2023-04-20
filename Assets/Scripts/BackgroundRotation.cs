using UnityEngine;

namespace Multipliers
{
    public class BackgroundRotation : MonoBehaviour
    {
        void Start()
        {
            var rectTransform = GetComponent<RectTransform>();
            float zRotation = Random.Range(-0.5f, 0.5f);
            float rndXPosition = Random.Range(-4f, 4f);
            float rndYPosition = Random.Range(-2.5f, 2.5f);

            rectTransform.Rotate(0, 0, zRotation);
            rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(rndXPosition, rndYPosition);
        }
    }
}