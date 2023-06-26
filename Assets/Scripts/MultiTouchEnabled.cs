using UnityEngine;

namespace Multipliers
{
    public class MultiTouchEnabled : MonoBehaviour
    {
        void Start()
        {
            Input.multiTouchEnabled = false;
        }
    }
}