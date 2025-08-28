# Time Channels for Unity

A lightweight, modular time control system that replaces Unity's global `Time.timeScale` with per-system time scaling.

## Why Use Time Channels?

Unity's `Time.timeScale` affects everything globally. Time Channels let you:

- Control individual systems independently
- Pause UI while gameplay continues  
- Create slow-motion effects for specific objects
- Run multiple timelines simultaneously

## Quick Start

### Basic Usage

```csharp
// Register a time channel
TimeChannelManager.Register("Player", SupportedTime.DeltaTime);

// Use in your Update loop
float dt = TimeChannelManager.Get("Player").DeltaTime;
transform.Translate(Vector3.forward * speed * dt);

// Control time scale
TimeChannelManager.Get("Player").TimeScale = 0.5f; // Slow motion
```

### Advanced Usage with Signals

```csharp
public class MovingObject : MonoBehaviour
{
    [SerializeField] private TimeChannelSignal signal;
    
    void Update()
    {
        // Automatically uses the signal's time channel
        float dt = signal.Channel.DeltaTime;
        transform.Translate(Vector3.forward * speed * dt);
    }
}
```

## Core Components

| Component | Purpose |
|-----------|---------|
| `TimeChannelManager` | Register and manage named channels |
| `TimeChannel` | Core time channel with `DeltaTime` and `TimeScale` |
| `TimeChannelFactory` | Create standalone channels |
| `TimeChannelSignal` | Advanced time control effects |

## Common Patterns

**Pause/Resume System:**
```csharp
var channel = TimeChannelManager.Get("Enemies");
float prevScale = channel.TimeScale;

// Pause
channel.TimeScale = 0f;

// Resume  
channel.TimeScale = prevScale;
```

**Independent Timelines:**
```csharp
// Different systems, different time scales
TimeChannelManager.Register("Player", SupportedTime.DeltaTime);
TimeChannelManager.Register("Weather", SupportedTime.DeltaTime);
TimeChannelManager.Register("UI", SupportedTime.UnscaledDeltaTime);

TimeChannelManager.Get("Player").TimeScale = 1.0f;   // Normal speed
TimeChannelManager.Get("Weather").TimeScale = 0.3f;  // Slow weather
TimeChannelManager.Get("UI").TimeScale = 1.0f;       // Always normal
```

## Samples

Import samples via **Window > Package Manager > Time Channels > Samples**:

- **BasicExample**: Fundamental usage patterns
- **TimeControlExample**: Advanced effects with `TimeChannelSignal`

## Best Practices

- Register channels early (e.g., in `Awake()` or `Start()`)
- Use meaningful channel names ("Player", "Enemies", "Weather")
- Clean up channels when no longer needed with `TimeChannelManager.Unregister()`
- Avoid mixing Unity's global `Time.timeScale` with Time Channels

## Events and Callbacks

```csharp
var channel = TimeChannelManager.Get("Player");
channel.OnTimeScaleChanged += (newScale) => {
    Debug.Log($"Player time scale changed to: {newScale}");
};
```

## Requirements

- Unity 2019.4 or newer
- No additional dependencies

---

For more examples and detailed documentation, visit the [GitHub repository](https://github.com/bcoffee0630/game-core-time-channels).
