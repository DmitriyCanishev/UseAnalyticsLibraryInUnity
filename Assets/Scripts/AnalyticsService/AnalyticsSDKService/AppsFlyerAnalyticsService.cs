using UnityEngine;

namespace AnalyticsService.AnalyticsSDKService
{
    public class AppsFlyerAnalyticsService
    {
        private const string ApiKey = "ApiKey";

        public AndroidJavaObject appsFlyerService;

        public void Init()
        {
            AndroidJavaObject appsFlyerServiceClass = new AndroidJavaObject("com.analytics.sdk.appsflyer.AppsFlyerAnalyticsService");
            var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                .GetStatic<AndroidJavaObject>("currentActivity");

            appsFlyerServiceClass.Call(
                methodName: "init", 
                activity, 
                ApiKey);

            appsFlyerService = appsFlyerServiceClass;
        }
    }
}