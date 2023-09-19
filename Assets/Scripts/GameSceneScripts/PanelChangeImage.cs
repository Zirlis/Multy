using System.Collections.Generic;
using UnityEngine;

namespace Multipliers
{
    public class PanelChangeImage : MonoBehaviour
    {
        private int _animationCount = 3;
        [HideInInspector] public int PanelAnimationVersion;
        [HideInInspector] public bool IsConnecteed = false;
        [HideInInspector] public static List<int> AvailableVersion;

        private void Awake()
        {
            if(AvailableVersion == null || AvailableVersion.Count == 0)
            {
                AvailableVersion = new List<int>();
                for (int i = 0; i < _animationCount; i++)                
                    AvailableVersion.Add(i);                
            }

            PanelAnimationVersion = AvailableVersion[Random.Range(0, AvailableVersion.Count)];
            AvailableVersion.Remove(PanelAnimationVersion);

            gameObject.GetComponent<Animator>().Play($"Unconnected{PanelAnimationVersion}");
        }
    }
}