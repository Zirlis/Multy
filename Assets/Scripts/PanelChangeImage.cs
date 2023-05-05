using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Multipliers
{
    public class PanelChangeImage : MonoBehaviour
    {
        [SerializeField] private int _animationCount = 1;
        [HideInInspector] public int PanelAnimationVersion;
        [HideInInspector] public bool IsConnecteed = false;

        private void Awake()
        {
            PanelAnimationVersion = Random.Range(0, _animationCount);

            gameObject.GetComponent<Animator>().Play($"Unconnected{PanelAnimationVersion}");
        }
    }
}