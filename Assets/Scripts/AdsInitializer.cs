using UnityEngine;
using UnityEngine.Advertisements;

namespace Multipliers
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        private void Awake()
        {
            InitializeAds();
        }

        private void InitializeAds()
        {
            Advertisement.Initialize("5328093", false, this);
        }

        public void OnInitializationComplete()
        {

        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {

        }        
    }
}