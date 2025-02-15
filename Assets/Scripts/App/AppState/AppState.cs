#nullable enable
using System.Collections.Generic;
using App.Analytics;
using UnityEngine;

namespace App.AppState
{
    public class AppState : MonoBehaviour
    {
        private AnalyticsLogger _analyticsLogger = null;

        private void Awake()
        {
            _analyticsLogger = new AnalyticsLogger();
        }

        public void SendEvent(string eventName)
        {
            _analyticsLogger.SendEvent(eventName);
        }

        public void SendEvent(string eventName, Dictionary<string, object>? eventParams)
        {
            _analyticsLogger.SendEvent(eventName, eventParams);
        }

    }
}