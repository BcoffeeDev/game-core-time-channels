using System;
using UnityEngine;

namespace BCF.Core.TimeChannels
{
    /// <summary>
    /// Provides factory methods to create time channels based on Unity's built-in time sources.
    /// </summary>
    public static class TimeChannelFactory
    {
        public static TimeChannel Create(SupportedTime type, float timeScale = 1f)
        {
            return new TimeChannel(type, GetProvider(type), timeScale);
        }

        private static Func<float> GetProvider(SupportedTime type)
        {
            return type switch
            {
                SupportedTime.DeltaTime => () => Time.deltaTime,
                SupportedTime.FixedDeltaTime => () => Time.fixedDeltaTime,
                SupportedTime.UnscaledDeltaTime => () => Time.unscaledDeltaTime,
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported time type: {type}")
            };
        }
    }
}