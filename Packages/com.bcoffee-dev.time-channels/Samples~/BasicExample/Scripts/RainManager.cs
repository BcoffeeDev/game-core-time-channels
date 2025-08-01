using UnityEngine;
using Random = UnityEngine.Random;

namespace BCF.Core.TimeChannels.Samples
{
    public class RainManager : MonoBehaviour
    {
        [SerializeField] private GameObject raindropPrefab;

        private bool _paused;
        private TimeChannel _timeChannel;

        private const string CHANNEL_NAME = "RainDrop";
        
        private void Start()
        {
            _timeChannel = TimeChannelManager.Register(CHANNEL_NAME, SupportedTime.DeltaTime);
            InvokeRepeating(nameof(SpawnRaindrop), 0f, 0.3f);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _paused = !_paused;
                TimeChannelManager.Get(CHANNEL_NAME).TimeScale = _paused ? 0 : 1;
            }
        }

        private void SpawnRaindrop()
        {
            if (_paused)
                return;
            var drop = Instantiate(raindropPrefab, new Vector3(Random.Range(-5f, 5f), 5f, 0), Quaternion.identity);
            drop.AddComponent<Raindrop>().Init(dtSource: () => TimeChannelManager.Get(CHANNEL_NAME).DeltaTime);
        }
    }
}