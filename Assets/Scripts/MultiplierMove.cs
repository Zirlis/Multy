using UnityEngine;
using UnityEngine.EventSystems;

namespace Multipliers
{
    public class MultiplierMove : MonoBehaviour
    {
        private void Start()
        {
            gameObject.AddComponent<EventTrigger>();
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.Drag;
            entry.callback.AddListener((data) => Move());
            trigger.triggers.Add(entry);
        }

        public void Move()
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }
}