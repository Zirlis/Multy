using UnityEngine;
using UnityEngine.Advertisements;

namespace Multipliers
{
    public class Ads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private void Awake()
        {
            LoadAd();
        }

        private void LoadAd()
        {
            Advertisement.Load("Interstitial_Android", this);
        }

        public void ShowAd()
        {
            Advertisement.Show("Interstitial_Android", this);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {

        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {

        }

        public void OnUnityAdsShowClick(string placementId)
        {

        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {

        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {

        }

        public void OnUnityAdsShowStart(string placementId)
        {
            LoadAd();
        }        
    }
}