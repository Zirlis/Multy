using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Multipliers
{
    public class Movement : MonoBehaviour
    {
        private Vector3 _firstMultiplier1;
        private Vector3 _firstMultiplier2;

        private float _distance;
        public float MovementTime = 0.5f;
        private static float _currentDistance;

        private LevelGenerator _levelGenerator;

        private void Start()
        {
            _levelGenerator = GetComponent<LevelGenerator>();

            _firstMultiplier1 = _levelGenerator.FirstMultiplier1.gameObject.transform.position;
            _firstMultiplier2 = _levelGenerator.FirstMultiplier2.gameObject.transform.position;
            _distance = _firstMultiplier2.x - _firstMultiplier1.x;
        }

        public IEnumerator MovementOnLine (GameObject obj)
        {
            var parent = obj.GetComponent<AddBeginDrag>().Original;

            for (int i = obj.transform.GetSiblingIndex(); i < 5; i++)
            {
                parent.transform.parent.GetChild(i).GetComponent<TextMeshProUGUI>().SetText
                    (parent.transform.parent.GetChild(i+1).GetComponent<TextMeshProUGUI>().text);
            }

            _currentDistance = 0f;
            List<RectTransform> requiringRelocation = new List<RectTransform>();

            parent.transform.parent.GetComponent<BoxCollider2D>().enabled = false;

            for (int i = 5; i > 0; i--)
            {
                if (obj.transform.parent.GetChild(i) != obj)
                {
                    obj.transform.parent.GetChild(i).GetComponent<TextMeshProUGUI>().SetText
                        (parent.transform.parent.GetChild(i - 1).GetComponent<TextMeshProUGUI>().text);
                    requiringRelocation.Add(obj.transform.parent.GetChild(i).GetComponent<RectTransform>());
                    if (i != 5)
                    {
                        requiringRelocation.Add(parent.transform.parent.GetChild(i + 6).GetComponent<RectTransform>());
                    }
                }
                else
                {
                    break;
                }
            }

            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;

                foreach (RectTransform rectTransform in requiringRelocation)
                {
                    rectTransform.anchoredPosition += new Vector2(_currentDistance, 0);
                }

                yield return null;
            }

            parent.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}