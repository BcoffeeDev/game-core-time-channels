using UnityEngine;
using Random = UnityEngine.Random;

namespace BCF.Core.TimeChannels.Samples
{
    public class TimeChannelDemo : MonoBehaviour
    {
        private bool playerPaused = false;
        private bool weatherPaused = false;

        public GameObject player;
        public GameObject raindropPrefab;

        private void Start()
        {
            TimeChannelManager.Register("Player", SupportedTime.DeltaTime);
            TimeChannelManager.Register("Weather", SupportedTime.DeltaTime);

            InvokeRepeating(nameof(SpawnRaindrop), 0f, 0.3f);
        }

        private void Update()
        {
            // control player movement
            float dt = TimeChannelManager.Get("Player").DeltaTime;
            float movement = Mathf.Sin(Time.time * 2f) * dt * 2f;
            player.transform.Translate(Vector3.right * movement);

            // change player time
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerPaused = !playerPaused;
                TimeChannelManager.Get("Player").TimeScale = playerPaused ? 0f : 1f;
            }

            // change weather time
            if (Input.GetMouseButtonDown(0))
            {
                weatherPaused = !weatherPaused;
                TimeChannelManager.Get("Weather").TimeScale = weatherPaused ? 0f : 1f;
            }
        }

        private void SpawnRaindrop()
        {
            if (weatherPaused)
                return;
            var drop = Instantiate(raindropPrefab, new Vector3(Random.Range(-5f, 5f), 5f, 0), Quaternion.identity);
            drop.AddComponent<Raindrop>().Init(dtSource: () => TimeChannelManager.Get("Weather").DeltaTime);
        }
    }
}