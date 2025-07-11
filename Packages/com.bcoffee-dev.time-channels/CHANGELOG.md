# Changelog

All notable changes to this project will be documented in this file.

## [1.1.0] - 2025-07-12

### Added

- Added `OnTimeScaleChanged` event to `TimeChannel.cs`, allowing subscribers to react when the time scale is modified.

### Changed

- Modified `TimeChannelManager.Register` to return the registered channel. If the channel already exists, it is returned instead of creating a new one.

## [1.0.0] - 2025-07-06

### Added

- Introduced `TimeChannel` class for modular time scaling.
- Implemented `SupportedTime` enum for Unity built-in time types (`deltaTime`, `fixedDeltaTime`, `unscaledDeltaTime`).
- Added `TimeChannelFactory` to abstract channel creation by type.
- Added `TimeChannelManager` with string-based registration for flexible channel naming.
- Included sample demo:
  - `TimeChannelDemo.cs` — controls player movement and weather with individual time channels.
  - `Raindrop.cs` — shows per-object motion based on a custom time channel.
- Enabled runtime pausing/resuming of specific time channels via keyboard/mouse input.

### Notes

- This is the initial stable release for open-source use.
- Designed for use under `Packages/com.bcoffee-dev.time-channels` in Unity.