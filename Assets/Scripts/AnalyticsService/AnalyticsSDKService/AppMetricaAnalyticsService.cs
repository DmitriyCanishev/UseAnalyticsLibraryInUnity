using UnityEngine;

namespace AnalyticsService.AnalyticsSDKService
{
    public class AppMetricaAnalyticsService
    {
        private const string ApiKey = "ApiKey";

        public AndroidJavaObject appMetricaService;

        public void Init()
        {
            AndroidJavaObject appMetricaServiceClass = new AndroidJavaObject("com.analytics.sdk.appmetrica.AppMetricaAnalyticsService");
            var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                .GetStatic<AndroidJavaObject>("currentActivity");

            appMetricaServiceClass.Call(
                methodName: "init", 
                activity, 
                ApiKey);

            appMetricaService = appMetricaServiceClass;
        }
    }
}