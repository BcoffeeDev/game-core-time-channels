using System;
using UnityEngine;

namespace BCF.Core.TimeChannels.Experimental
{
    public class TimeChannelSignal : MonoBehaviour
    {
        [SerializeField] private SupportedTime timeType;
        [SerializeField] private float initTimeScale = 1f;
        
        /// <summary>
        /// ID to register a unique channel for this signal.
        /// </summary>
        public string SignalId { get; private set; }
        /// <summary>
        /// A time channel register on awake using unique id.
        /// This channel will unregister on destroy.
        /// </summary>
        public TimeChannel Channel { get; private set; }
        
        private void Awake()
        {
            SignalId = Guid.NewGuid().ToString();
            Channel = TimeChannelManager.Register(SignalId, timeType, initTimeScale);
        }

        private void OnDestroy()
        {
            TimeChannelManager.Unregister(SignalId);
        }
    }
}