using System;
using UnityEngine;

namespace BCF.Core.TimeChannels
{
    /// <summary>
    /// Represents a single time channel with an adjustable time scale.
    /// </summary>
    public class TimeChannel
    {
        private readonly Func<float> _baseTimeProvider;
        public event Action<float> OnTimeScaleChanged; 

        private float _timeScale;

        #region Properties

        public SupportedTime Type { get; }

        public float TimeScale
        {
            get => _timeScale;
            set
            {
                if (Mathf.Approximately(_timeScale, value)) return; // command this line if you want to trigger callback with same value.
                _timeScale = value;
                OnTimeScaleChanged?.Invoke(_timeScale);
            }
        }
        
        /// <summary>
        /// Gets the delta time adjusted by the channel's time scale.
        /// </summary>
        public float DeltaTime => _baseTimeProvider() * TimeScale;

        #endregion
        
        public TimeChannel(SupportedTime type, Func<float> baseTimeProvider, float timeScale = 1f)
        {
            Type = type;
            _baseTimeProvider = baseTimeProvider;
            TimeScale = timeScale;
        }
    }
}