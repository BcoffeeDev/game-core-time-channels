using UnityEngine;

namespace BCF.Core.TimeChannels.Samples
{
    public class MovingCube : MonoBehaviour
    {
        [SerializeField] private float distance = 6;
        [SerializeField] private float speed = 5;

        private Vector3 _startPosition;
        private float _direction = 1f; 
        private float _currentOffset = 0f;
        private TimeChannel _timeChannel;
        private bool _paused = false;
        
        private const string CHANNEL_NAME = "MovingCube";

        private void Start()
        {
            _startPosition = transform.position;
            _timeChannel = TimeChannelManager.Register(CHANNEL_NAME, SupportedTime.DeltaTime);
        }

        private void OnDestroy()
        {
            TimeChannelManager.Unregister(CHANNEL_NAME);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _paused = !_paused;
                TimeChannelManager.Get(CHANNEL_NAME).TimeScale = _paused ? 0 : 1;
            }
            
            var dt = _timeChannel.DeltaTime;
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