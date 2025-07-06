# game-core-time-channels

Modular Time Channel System for Unity — fine-grained control over time flow across systems.

---

## ✨ Features

- 🎛 **Per-System Time Scaling** — apply different `TimeScale` values to player, weather, enemies, etc.
- 🧱 **Modular Architecture** — clearly separates channel creation, management, and usage.
- 🔑 **String-Based Channel Naming** — register and retrieve custom time channels easily.
- 🔄 **Pause/Resume Per Channel** — control specific systems without affecting the whole game.
- 📦 **UPM-ready structure** — designed for Unity `Packages/com.bcoffee-dev.time-channels`.

---

## 📦 Installation

You can install this package via Git URL by adding the following to your `manifest.json`:

```json
"com.bcoffee-dev.time-channels": "https://github.com/BcoffeeDev/game-core-time-channels.git?path=Packages/com.bcoffee-dev.time-channels"
```

Or use Unity Package Manager:

1. Open **Window > Package Manager**
2. Click the **+** button and select **Add package from Git URL...**
3. Paste the URL:
   ```
   https://github.com/BcoffeeDev/game-core-time-channels.git?path=Packages/com.bcoffee-dev.time-channels
   ```

Make sure you are using Unity 2019.4 or newer to support Git-based packages.

## 🚀 Getting Started

### 1. Register a time channel

```csharp
TimeChannelManager.Register("Player", SupportedTime.DeltaTime);
```

### 2. Access time in Update loop

```csharp
float dt = TimeChannelManager.Get("Player").DeltaTime;
```

### 3. Change time scale at runtime

```csharp
TimeChannelManager.Get("Player").TimeScale = 0.5f; // Slow motion
```

---

## 🧪 Sample Included

This package includes a basic usage sample available via Unity's Package Manager.

### To import the sample:

1. Open **Window > Package Manager**
2. Select `Time Channels`
3. Click the **Samples** tab
4. Click **Import** on **BasicExample**

The sample demonstrates:
- Independent time control for player and weather
- Toggling movement and raindrops via keyboard/mouse

---

## 📄 License

MIT License © 2025 [Bcoffee](https://github.com/bcoffee0630)