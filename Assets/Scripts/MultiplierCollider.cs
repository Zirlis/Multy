using System;
using UnityEngine;

namespace Multipliers
{
    public class MultiplierCollider : MonoBehaviour
    {
        public static event Action<GameObject, GameObject> OnEndDrag;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnEndDrag?.Invoke(gameObject, collision.gameObject);
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log(collision.name);
        }
    }
}