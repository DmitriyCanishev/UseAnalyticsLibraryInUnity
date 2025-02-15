#nullable enable
using System.Collections.Generic;
using AnalyticsService.AnalyticsSDKService;
using AnalyticsService.Extensions;
using UnityEngine;

namespace AnalyticsService.Service
{
    public class AnalyticsServiceWrapper
    {
        private AndroidJavaObject _analyticsService = null;

        private AppMetricaAnalyticsService _appMetricaAnalyticsService = null;
        private AppsFlyerAnalyticsService _appsFlyerAnalyticsService = null;
        private FirebaseAnalyticsService _firebaseAnalyticsService = null;

        public void LogEvent(string eventName)
        {
            Debug.LogError("AnalyticsService -> Log Event");
#if !UNITY_EDITOR && UNITY_ANDROID
            _analyticsService.Call(
                methodName: "logEvent",
                new object[]
                {
                    eventName,
                    null
                }
            );
#endif
        }

        public void LogEventWithParams(string eventName, Dictionary<string, object>? eventParams)
        {
            Debug.LogError("AnalyticsService -> Log Event with params");
#if UNITY_ANDROID && !UNITY_EDITOR
            _analyticsService.Call(
                methodName: "logEvent",
                new object[]
                {
                    eventName,
                    eventParams.CreateHashMap()
                }
            );
#endif
        }

        public void Init()
        {
            Debug.LogError("AnalyticsService -> Init");
            CreateAnalytics();
            InitService();
        }

        private void InitService()
        {
            AndroidJavaObject analyticsService =
                new AndroidJavaObject("com.analytics.service.unity.UnityAnalyticsService");

            List<AndroidJavaObject> analyticsList = new List<AndroidJavaObject>
            {
                _appMetricaAnalyticsService.appMetricaService,
                _firebaseAnalyticsService.firebaseService,
                _appsFlyerAnalyticsService.appsFlyerService
            };

            foreach (var analyticsObject in analyticsList)
            {
                analyticsService.Call(
                    methodName: "collectAnalytics",
                    new object[]
                    {
                        analyticsObject
                    }
                );
            }

            analyticsService.Call(methodName: "init");

            _analyticsService = analyticsService;
        }

        private void CreateAnalytics()
        {
            _appMetricaAnalyticsService = new AppMetricaAnalyticsService();
            _appMetricaAnalyticsService.Init();
            
            _appsFlyerAnalyticsService = new AppsFlyerAnalyticsService();
            _appsFlyerAnalyticsService.Init();
            
            _firebaseAnalyticsService = new FirebaseAnalyticsService();
            _firebaseAnalyticsService.Init();
        }
    }
}