using System;

namespace BCF.Core.TimeChannels
{
    /// <summary>
    /// Represents a single time channel with an adjustable time scale.
    /// </summary>
    public class TimeChannel
    {
        public SupportedTime Type { get; }
        public float TimeScale { get; set; }

        private readonly Func<float> _baseTimeProvider;

        public TimeChannel(SupportedTime type, Func<float> baseTimeProvider, float timeScale = 1f)
        {
            Type = type;
            _baseTimeProvider = baseTimeProvider;
            TimeScale = timeScale;
        }

        /// <summary>
        /// Gets the delta time adjusted by the channel's time scale.
        /// </summary>
        public float DeltaTime => _baseTimeProvider() * TimeScale;
    }
}