using UnityEngine;

namespace AnalyticsService.AnalyticsSDKService
{
    public class FirebaseAnalyticsService
    {
        public AndroidJavaObject firebaseService;

        public void Init()
        {
            AndroidJavaObject firebaseServiceClass = new AndroidJavaObject("com.analytics.sdk.firebase.FirebaseAnalyticsService");
            var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                .GetStatic<AndroidJavaObject>("currentActivity");

            firebaseServiceClass.Call(
                methodName: "init", 
                activity);

            firebaseService = firebaseServiceClass;
        }
    }
}