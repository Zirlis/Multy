using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

namespace Multipliers
{
    public class MultiplierClickDown : MonoBehaviour, IPointerDownHandler
    {
        [HideInInspector] public GameObject MultiplierClone;
        [SerializeField] MultiplierMove MultiplierMove;

        public static Action<GameObject, GameObject> onUpped;
        public void OnPointerDown(PointerEventData eventData)
        {
            MultiplierClone = Instantiate(gameObject, transform.position, Quaternion.identity);
            MultiplierClone.transform.SetParent(transform.parent.parent);
            MultiplierClone.GetComponent<TextMeshProUGUI>().enableAutoSizing = false;
            MultiplierClone.GetComponent<TextMeshProUGUI>().fontSize = GetComponent<TextMeshProUGUI>().fontSize;
            GetComponent<TextMeshProUGUI>().SetText("");
            MultiplierClone.AddComponent<MultiplierMove>();
            onUpped?.Invoke(gameObject, MultiplierClone);
        }        
    }
}