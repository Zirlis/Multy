using UnityEngine;
using UnityEngine.EventSystems;

namespace Multipliers
{
    public class AddDrag : MonoBehaviour
    {
        private AddBeginDrag _addBeginDrag;

        EventTrigger.Entry entry;

        private void Start()
        {
            if (!GetComponent<EventTrigger>())            
                gameObject.AddComponent<EventTrigger>();

            EventTrigger trigger = GetComponent<EventTrigger>();
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => Move());
            trigger.triggers.Add(entry);

            _addBeginDrag = GetComponent<AddBeginDrag>();
        }

        private void OnDestroy()
        {
            entry.callback.RemoveListener((data) => Move());
        }

        public void Move()
        {
            if (_addBeginDrag.BeginDrag)            
                transform.position = Input.mousePosition;            
        }
    }
}