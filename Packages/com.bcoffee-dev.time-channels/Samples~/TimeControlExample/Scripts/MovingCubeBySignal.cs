using BCF.Core.TimeChannels.Experimental;
using UnityEngine;

namespace BCF.Core.TimeChannels.Samples
{
    public class MovingCubeBySignal : MonoBehaviour
    {
        [SerializeField] private TimeChannelSignal signal;
        [SerializeField] private float distance = 6;
        [SerializeField] private float speed = 5;

        private Vector3 _startPosition;
        private float _direction = 1f; 
        private float _currentOffset = 0f;

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (signal.Channel == null)
                return;
            var dt = signal.Channel.DeltaTime;
            var deltaMove = speed * dt * _direction;
            _currentOffset += deltaMove;

            if (Mathf.Abs(_currentOffset) > distance)
            {
                _direction *= -1f;
                _currentOffset = Mathf.Clamp(_currentOffset, -distance, distance);
            }

            transform.position = _startPosition + Vector3.right * _currentOffset;
        }
    }
}