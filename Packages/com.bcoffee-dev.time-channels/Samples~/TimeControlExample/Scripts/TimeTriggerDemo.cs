using BCF.Core.TimeChannels.Experimental;
using UnityEngine;

namespace BCF.Core.TimeChannels.Samples
{
    public class TimeTriggerDemo : MonoBehaviour
    {
        [SerializeField] private float multiplier = 0.5f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out TimeChannelSignal signal))
                return;
            signal.Channel.TimeScale *= multiplier;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out TimeChannelSignal signal))
                return;
            signal.Channel.TimeScale /= multiplier;
        }
    }
}