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

        [SerializeField] private float _distance;
        public float MovementTime = 0.5f;
        [SerializeField] private float _currentDistance;

        private LevelGenerator _levelGenerator;

        private void Start()
        {
            _levelGenerator = GetComponent<LevelGenerator>();

            _firstMultiplier1 = _levelGenerator.FirstMultiplier1.gameObject.transform.position;
            _firstMultiplier2 = _levelGenerator.FirstMultiplier2.gameObject.transform.position;
            _distance =_firstMultiplier1.x - _firstMultiplier2.x;
        }

        public void Coroutine(GameObject obj)
        {
            StartCoroutine(MovementOnLine(obj));
        }

        private IEnumerator MovementOnLine (GameObject obj)
        {
            var objAddBeginDrag = obj.GetComponent<AddBeginDrag>();
            var parent = objAddBeginDrag.Original;

            var originalMultiplicator = parent.transform.parent.GetChild(obj.transform.GetSiblingIndex() + 6).gameObject;
            originalMultiplicator.SetActive(false);

            for (int i = obj.transform.GetSiblingIndex(); i < 5; i++)
            {
                parent.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText
                    (parent.transform.parent.GetChild(i+1).gameObject.GetComponent<TextMeshProUGUI>().text);
            }

            parent.transform.parent.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

            _currentDistance = 0f;
            List<RectTransform> requiringRelocation = new List<RectTransform>();

            var panelCollider = parent.transform.parent.GetComponent<BoxCollider2D>();
            panelCollider.enabled = false;            

            for (int i = 5; i > 0; i--)
            {
                if (obj.transform.parent.GetChild(i).gameObject != obj)
                {
                    obj.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText
                        (parent.transform.parent.GetChild(i - 1).gameObject.GetComponent<TextMeshProUGUI>().text);
                    requiringRelocation.Add(obj.transform.parent.GetChild(i).gameObject.GetComponent<RectTransform>());
                    if (i != 5)
                    {
                        requiringRelocation.Add(parent.transform.parent.GetChild(i + 6).gameObject.GetComponent<RectTransform>());
                    }
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (i != obj.transform.GetSiblingIndex())
                {
                    obj.transform.parent.GetChild(i).gameObject.GetComponent<AddBeginDrag>().AllowBeginDrag = false;
                }

                parent.transform.parent.GetChild(i).gameObject.SetActive(false);
            }

            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;

                foreach (RectTransform rectTransform in requiringRelocation)
                {
                    rectTransform.anchoredPosition += new Vector2(_distance / MovementTime * Time.deltaTime, 0);
                }

                yield return null;
            }

            foreach (RectTransform rectTransform in requiringRelocation)
            {
                rectTransform.anchoredPosition = Vector2.zero;
            }

            for (int i = 0; i < 6; i++)
            {
                parent.transform.parent.GetChild(i).gameObject.SetActive(true);

                if (i != obj.transform.GetSiblingIndex())
                {
                    var cloneInPanel = obj.transform.parent.GetChild(i).gameObject;
                    cloneInPanel.GetComponent<AddBeginDrag>().AllowBeginDrag = true;
                    cloneInPanel.GetComponent<TextMeshProUGUI>().SetText("");
                }

                if(i!=0)
                {
                    if(parent.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text == "")
                    {
                        parent.transform.parent.GetChild(i+5).gameObject.SetActive(false);
                    }
                }
            }

            originalMultiplicator.SetActive(true);

            panelCollider.enabled = true;
        }
    }
}