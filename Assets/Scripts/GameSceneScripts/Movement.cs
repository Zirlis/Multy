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
        [SerializeField] private float MovementTime = 0.5f;
        [SerializeField] private float _currentDistance;

        private LevelGenerator _levelGenerator;

        private GameObject _original;
        private int _siblingIndex;
        private BoxCollider2D _panelCollider;
        private GameObject _originalMultiplicator;
        private List<RectTransform> _requiringRelocation;

        private void Start()
        {
            _levelGenerator = GetComponent<LevelGenerator>();

            _firstMultiplier1 = _levelGenerator.FirstMultipliers[0].gameObject.transform.position;
            _firstMultiplier2 = _levelGenerator.FirstMultipliers[1].gameObject.transform.position;
            _distance =_firstMultiplier1.x - _firstMultiplier2.x;
        }

        public void Coroutine(GameObject multiplier)
        {
            StartCoroutine(MovementOnLine(multiplier));
        }

        private IEnumerator MovementOnLine (GameObject multiplier)
        {
            _requiringRelocation = new List<RectTransform>();
            _original = multiplier.GetComponent<AddBeginDrag>().Original;

            BlockingChanges(multiplier);
            _currentDistance = 0f;

            for (int i = 5; i > multiplier.transform.GetSiblingIndex(); i--)
            {
                multiplier.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText
                        (_original.transform.parent.GetChild(i - 1).gameObject.GetComponent<TextMeshProUGUI>().text);
                _requiringRelocation.Add(multiplier.transform.parent.GetChild(i).gameObject.GetComponent<RectTransform>());
                if (i != 5)                
                    _requiringRelocation.Add(_original.transform.parent.GetChild(i + 6).gameObject.GetComponent<RectTransform>());                
            }

            while (_currentDistance < _distance)
            {
                _currentDistance += _distance / MovementTime * Time.deltaTime;

                foreach (RectTransform rectTransform in _requiringRelocation)                
                    rectTransform.anchoredPosition += new Vector2(_distance / MovementTime * Time.deltaTime, 0);
                

                yield return null;
            }

            foreach (RectTransform rectTransform in _requiringRelocation)            
                rectTransform.anchoredPosition = Vector2.zero;
            

            UnblockingChanges(multiplier);
        }

        private void BlockingChanges(GameObject multiplier)
        {            
            _originalMultiplicator = _original.transform.parent.GetChild(multiplier.transform.GetSiblingIndex() + 6).gameObject;
            _originalMultiplicator.SetActive(false);

            for (int i = multiplier.transform.GetSiblingIndex(); i < 5; i++)            
                _original.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().SetText
                    (_original.transform.parent.GetChild(i + 1).gameObject.GetComponent<TextMeshProUGUI>().text);            

            _original.transform.parent.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().SetText("");

            _panelCollider = _original.transform.parent.GetComponent<BoxCollider2D>();
            _panelCollider.enabled = false;

            for (int i = 0; i < 6; i++)            
                if (i != multiplier.transform.GetSiblingIndex())
                    multiplier.transform.parent.GetChild(i).gameObject.GetComponent<AddBeginDrag>().AllowBeginDrag = false;            

            _siblingIndex = multiplier.transform.GetSiblingIndex();
            Transform multipiersParent = multiplier.GetComponent<AddBeginDrag>().Original.transform.parent;

            if (_siblingIndex != 0 && _siblingIndex != multiplier.transform.parent.childCount - 1
                && multipiersParent.GetChild(multiplier.transform.GetSiblingIndex()).gameObject.GetComponent<TextMeshProUGUI>().text == "")
                   multipiersParent.GetChild(multiplier.transform.GetSiblingIndex() + 5).gameObject.SetActive(false);

            for (int i = 5; i >= multiplier.transform.GetSiblingIndex(); i--)
                _original.transform.parent.GetChild(i).gameObject.SetActive(false);
        }

        private void UnblockingChanges(GameObject obj)
        {
            for (int i = 5; i >= obj.transform.GetSiblingIndex(); i--)            
                _original.transform.parent.GetChild(i).gameObject.SetActive(true);            

            for (int i = 0; i < 6; i++)
            {
                if (i != obj.transform.GetSiblingIndex())
                {
                    var cloneInPanel = obj.transform.parent.GetChild(i).gameObject;
                    cloneInPanel.GetComponent<AddBeginDrag>().AllowBeginDrag = true;
                    cloneInPanel.GetComponent<TextMeshProUGUI>().SetText("");
                }

                if (i != 0 && _original.transform.parent.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().text == "")
                    _original.transform.parent.GetChild(i + 5).gameObject.SetActive(false);
            }

            if (_siblingIndex != 5 && _original.transform.parent.GetChild(_siblingIndex + 1).gameObject.GetComponent<TextMeshProUGUI>().text != "")
                _originalMultiplicator.SetActive(true);

            _panelCollider.enabled = true;
        }
    }
}