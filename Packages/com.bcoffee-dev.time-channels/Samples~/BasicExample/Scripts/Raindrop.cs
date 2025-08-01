using System;
using UnityEngine;

namespace BCF.Core.TimeChannels.Samples
{
    public class Raindrop : MonoBehaviour
    {
        private Func<float> _dtSource;

        public void Init(Func<float> dtSource)
        {
            _dtSource = dtSource;
        }

        private void Update()
        {
            if (transform.position.y < -3f)
                Destroy(gameObject);
            else if (_dtSource != null)
                transform.Translate(Vector3.down * 5f * _dtSource());
        }
    }
}