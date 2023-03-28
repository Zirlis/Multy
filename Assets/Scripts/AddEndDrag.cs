using UnityEngine;
using UnityEngine.EventSystems;

namespace Multipliers
{
    public class AddEndDrag : MonoBehaviour
    {
        private void Start()
        {
            if (!GetComponent<EventTrigger>())
            {
                gameObject.AddComponent<EventTrigger>();
            }
            EventTrigger trigger = GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.EndDrag;
            entry.callback.AddListener((data) => EndDrag());
            trigger.triggers.Add(entry);
        }

        public void EndDrag()
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}