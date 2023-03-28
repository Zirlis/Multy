using UnityEngine;
using UnityEngine.EventSystems;

namespace Multipliers
{
    public class AddDrag : MonoBehaviour
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
        }

        public void Add()
        {
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => Move());
            trigger.triggers.Add(entry);
        }

        public void Move()
        {
            transform.position = Input.mousePosition;
        }
    }
}