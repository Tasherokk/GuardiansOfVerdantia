# Research & Decisions: Tower Defense MVP

This document outlines the high-level architectural decisions for the core systems of the Tower Defense MVP.

## Core Systems Design

### 1. Wave Spawning System
- **Decision**: Use ScriptableObjects to define wave configurations.
- **Rationale**: This approach allows for easy creation and modification of wave data without changing code. Designers can create new waves as assets in the Unity Editor. Each `Wave` ScriptableObject will contain a list of enemy prefabs, the number of enemies to spawn, and the time between spawns. A `WaveSpawner` MonoBehaviour will be responsible for reading these assets and executing the spawning logic.
- **Alternatives considered**: Hardcoding wave data (inflexible), JSON/XML files (requires extra parsing code and is less designer-friendly than ScriptableObjects).

### 2. Enemy AI & Movement
- **Decision**: A simple waypoint-based movement system.
- **Rationale**: For an MVP, a predefined path is sufficient. An `EnemyAI` script will be attached to each enemy prefab. On spawn, it will be given a reference to a list of waypoint transforms. The script will move the enemy from one waypoint to the next in sequence using `Vector3.MoveTowards`.
- **Alternatives considered**: A* pathfinding (overkill for a fixed-path TD), NavMesh (more suited for 3D or dynamic environments).

### 3. Tower & Placement System
- **Decision**: A base `Tower` class with subclasses for each tower type, and a grid-based placement system.
- **Rationale**: An object-oriented approach with a base class is clean and extensible. Each tower type (Thorns, Flames, Winds) will inherit from `Tower` and override methods for special abilities. For placement, the designated tower spots will have a script that listens for player input to build a tower if the player has enough mana.
- **Alternatives considered**: A single `Tower` class with an enum for type (less clean, can lead to large switch statements).

### 4. Economy (Mana) System
- **Decision**: A central `GameManager` (singleton) will manage the player's mana.
- **Rationale**: A singleton `GameManager` provides a global access point for game state, including mana. This is simple and effective for a single-scene MVP. The `GameManager` will have public methods to `AddMana` and `SpendMana`, with events that other systems (like the UI) can subscribe to.
- **Alternatives considered**: A dedicated `ManaSystem` class (slightly more decoupled, but adds complexity for an MVP).

### 5. UI System
- **Decision**: A `UIManager` class will manage all UI elements.
- **Rationale**: This centralizes UI logic. The `UIManager` will subscribe to events from the `GameManager` (for mana and core health changes) and the `WaveSpawner` (for wave number changes) to update the display. This event-based approach decouples the UI from the game logic.
- **Alternatives considered**: Having individual scripts for each UI element (can become messy and hard to manage).
