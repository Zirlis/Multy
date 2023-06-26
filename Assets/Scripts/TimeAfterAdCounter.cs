using UnityEngine;

namespace Multipliers
{
    public class TimeAfterAdCounter : MonoBehaviour
    {
        private void Update()
        {
            SecondaryInformation.TimeAfterAd += Time.deltaTime;
        }
    }
}