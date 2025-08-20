# game-core-time-channels

A lightweight and highly controllable time channel system for Unity — designed to replace Unity's global `Time.timeScale` with modular, per-system control.

---

## Why Not Use `Time.timeScale`?

Unity's built-in `Time.timeScale` affects the entire game globally, which limits your ability to create nuanced time effects. For example, you can't easily:

- Pause UI while gameplay continues.
- Slow down enemies without affecting player controls.
- Run multiple independent timelines in parallel.

`game-core-time-channels` solves these problems by allowing each gameplay system to operate on its own independently scaled timeline.

---

## ✨ Features

- **Per-System Time Scaling**: Assign unique time scales to players, enemies, weather, UI, and more.
- **Modular Architecture**: Clean separation of channel creation, management, and usage.
- **String-Based Channel Naming**: Easily register and retrieve custom time channels by name.
- **Pause/Resume Per Channel**: Control specific systems without impacting the entire game.
- **Flexible Signal System**: Use `TimeChannelSignal` to create complex, dynamic time effects.

---

## ⚙️ Requirements

- Unity 2019.4 or newer.
- Supports Git-based package installation.

---

## 🚀 Quick Start

### 1. Register a time channel

```csharp
TimeChannelManager.Register("Player", SupportedTime.DeltaTime);
```

### 2. Access time in your Update loop

```csharp
float dt = TimeChannelManager.Get("Player").DeltaTime;
```

### 3. Adjust time scale at runtime

```csharp
TimeChannelManager.Get("Player").TimeScale = 0.5f; // Slow motion effect
```

---

## 📖 Recipes

- **Create a custom time channel without the manager:**

```csharp
var customChannel = TimeChannelFactory.Create(SupportedTime.FixedDeltaTime);
customChannel.TimeScale = 0.8f;
float dt = customChannel.DeltaTime;
```

- **Pause and resume a specific channel:**

```csharp
var enemy = TimeChannelManager.Register("Enemy", SupportedTime.DeltaTime);

// Pause: set scale to 0 (remember previous scale if you need to restore it)
float prevScale = enemy.TimeScale;
enemy.TimeScale = 0f;

// Resume: restore previous scale (or set to 1f if you want the default)
enemy.TimeScale = prevScale; // or: enemy.TimeScale = 1f;
```
> `TimeChannel` has no built-in `Pause()`/`Resume()` methods. Pausing is done by setting `TimeScale` to `0f`, and resuming by restoring a non-zero scale.

- **Use `TimeChannelSignal` for advanced effects:**

`TimeChannelSignal` lets you send signals to one or multiple channels to produce various time effects such as slow motion, speed-up, freeze, or complete overrides. This flexible system allows you to compose complex time behaviors dynamically.

> Note: The included sample demonstrates only one possibility (slow-motion), but `TimeChannelSignal` supports a wide range of time manipulation effects.

---

## 📚 API Overview

- `TimeChannelManager` — Register, retrieve, and manage named time channels.
- `TimeChannel` — The core time channel object with properties like `DeltaTime`, `TimeScale`, and control methods.
- `TimeChannelFactory` — Create custom time channels independent of the manager.
- `TimeChannelSignal` — Send signals for complex time control across channels.

---

## ⚠️ Notes & Pitfalls

- Avoid relying on Unity’s global `Time.timeScale` if using this package.
- Remember to register all channels before use.
- Manage channel lifecycles carefully to prevent memory leaks.
- When mixing built-in Unity time and time channels, be mindful of synchronization issues.

---

## 🧪 Samples Included

The package includes two samples accessible via Unity Package Manager:

- **BasicExample**: Demonstrates fundamental usage of time channels.
- **TimeControlExample**: Shows how to use `TimeChannelSignal` for slow-motion effects (note: `TimeChannelSignal` supports many more effects beyond this demo).

To import samples:

1. Open **Window > Package Manager**
2. Select `Time Channels`
3. Click the **Samples** tab
4. Import the desired sample

---

## 🎥 Showcase

Here are short demo videos demonstrating the package in action:

- **Basic Example**  
  [▶ Watch basic_example.mp4](./showcase/basic_example.mp4)

- **Time Control Example**  
  [▶ Watch time_control_example.mp4](./showcase/time_control_example.mp4)

---

## 🆕 What's New

- Added support for multiple signal types in `TimeChannelSignal`.
- Improved performance for channel updates.
- Enhanced documentation and samples.

---

## 📄 License

MIT License © 2025 [Bcoffee](https://github.com/bcoffee0630)