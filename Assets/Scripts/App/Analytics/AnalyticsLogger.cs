#nullable enable
using System.Collections.Generic;
using AnalyticsService.Service;

namespace App.Analytics
{
    public class AnalyticsLogger
    {
        private AnalyticsServiceWrapper _analyticsService = null;

        public AnalyticsLogger()
        {
            InitService();
        }

        public void SendEvent(string eventName)
        {
            _analyticsService.LogEvent(eventName);
        }
        
        public void SendEvent(string eventName, Dictionary<string, object>? eventParams)
        {
            _analyticsService.LogEventWithParams(eventName, eventParams);
        }

        private void InitService()
        {
            _analyticsService = new AnalyticsServiceWrapper();
            _analyticsService.Init();
        }
    }
}