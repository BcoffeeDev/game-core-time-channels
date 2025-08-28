using System.Collections.Generic;

namespace BCF.Core.TimeChannels
{
    /// <summary>
    /// Default manager for time channels using string identifiers. Developers may replace it with custom managers.
    /// </summary>
    public static class TimeChannelManager
    {
        private static readonly Dictionary<string, TimeChannel> _channels = new();

        /// <summary>
        /// Registers a new time channel with the given name and time source. Does nothing if the name already exists.
        /// </summary>
        public static TimeChannel Register(string name, SupportedTime type, float defaultTimeScale = 1f)
        {
            if (!_channels.ContainsKey(name))
            {
                _channels[name] = TimeChannelFactory.Create(type, defaultTimeScale);
            }
            
            return _channels[name];
        }

        /// <summary>
        /// Returns true if a channel with the specified name exists.
        /// </summary>
        public static bool Has(string name) => _channels.ContainsKey(name);

        /// <summary>
        /// Gets the time channel by name. Throws if not found.
        /// </summary>
        public static TimeChannel Get(string name)
        {
            if (!_channels.TryGetValue(name, out var channel))
            {
                throw new KeyNotFoundException($"Time channel '{name}' not found.");
            }
            return channel;
        }

        /// <summary>
        /// Removes the time channel with the specified name.
        /// </summary>
        public static void Unregister(string name)
        {
            _channels.Remove(name);
        }

        /// <summary>
        /// Clears all registered time channels.
        /// </summary>
        public static void Clear()
        {
            _channels.Clear();
        }
    }
}