using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Multipliers
{
    public class MultiplierMove : MonoBehaviour
    {
        private void Start()
        {
            if (!GetComponent<EventTrigger>())
            {
                gameObject.AddComponent<EventTrigger>();
            }
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => Move());
            trigger.triggers.Add(entry);

            //entry.eventID = EventTriggerType.BeginDrag;
            //entry.callback.AddListener((data) => SetParentData());
            //trigger.triggers.Add(entry);
        }

        public void Move()
        {
            transform.position = Input.mousePosition;
        }

        //public void SetParentData()
        //{
        //    var parentText = transform.parent.GetComponent<TextMeshProUGUI>();
        //    GetComponent<TextMeshProUGUI>().SetText($"{parentText.text}");
        //    parentText.SetText("");
        //    Debug.Log(GetComponent<TextMeshProUGUI>().text);
        //}
    }
}