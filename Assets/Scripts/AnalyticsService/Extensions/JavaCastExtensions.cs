#nullable enable
using System.Collections.Generic;
using UnityEngine;

namespace AnalyticsService.Extensions
{
    public static class JavaCastExtensions
    {
        public static AndroidJavaObject? CreateHashMap(this Dictionary<string, object>? eventParams)
        {
            Debug.LogError("AnalyticsService -> eventParams converting");
            if (eventParams != null)
            {
                AndroidJavaObject hashMap = new AndroidJavaObject("java.util.HashMap");
                foreach (var entry in eventParams)
                {
                    object androidValue = ConvertToAndroidObject(entry.Value);
                    hashMap.Call<AndroidJavaObject>("put", entry.Key, androidValue);
                }

                return hashMap;
            }

            return null;
        }

        private static object ConvertToAndroidObject(object value) =>
            value switch
            {
                string _ => value,
                int _ => new AndroidJavaObject("java.lang.Integer", value),
                float _ => new AndroidJavaObject("java.lang.Float", value),
                bool _ => new AndroidJavaObject("java.lang.Boolean", value),
                long _ => new AndroidJavaObject("java.lang.Long", value),
                _ => "Unsupported type"
            };
    }
}