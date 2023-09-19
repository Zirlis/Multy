using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

namespace Multipliers
{
    public class AddBeginDrag : MonoBehaviour
    {
        public static event Action<GameObject> OnBeginDrag;
        public bool AllowBeginDrag = true;
        public bool BeginDrag = false;

        public GameObject Original;

        EventTrigger.Entry entry;

        private void Start()
        {
            if (!GetComponent<EventTrigger>())            
                gameObject.AddComponent<EventTrigger>();

            EventTrigger trigger = GetComponent<EventTrigger>();
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.BeginDrag;
            entry.callback.AddListener((data) => SetParentData());
            trigger.triggers.Add(entry);
        }

        private void OnDestroy()
        {
            entry.callback.RemoveListener((data) => SetParentData());
        }

        public void SetParentData()
        {
            if (AllowBeginDrag && !SecondaryInformation.AnyMultiplierWasRaised)
            {
                var parentText = Original.GetComponent<TextMeshProUGUI>();
                GetComponent<TextMeshProUGUI>().SetText($"{parentText.text}");
                parentText.SetText("");
                BeginDrag = true;
                OnBeginDrag?.Invoke(gameObject);
                SecondaryInformation.AnyMultiplierWasRaised = true;
            }
        }
    }
}