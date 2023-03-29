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
        private void Start()
        {
            if (!GetComponent<EventTrigger>())
            {
                gameObject.AddComponent<EventTrigger>();
            }
            Add();
        }

        public void Add()
        {
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.BeginDrag;
            entry.callback.AddListener((data) => SetParentData());
            trigger.triggers.Add(entry);
        }

        public void SetParentData()
        {
            if (AllowBeginDrag)
            {
                var parentText = Original.GetComponent<TextMeshProUGUI>();
                GetComponent<TextMeshProUGUI>().SetText($"{parentText.text}");
                parentText.SetText("");
                BeginDrag = true;
                OnBeginDrag?.Invoke(gameObject);
            }
        }
    }
}