# Data Model: Tower Defense MVP

This document describes the data structures and key entities for the game, primarily using ScriptableObjects for configuration and MonoBehaviours for in-game objects.

## Core Data Structures (ScriptableObjects)

These objects will hold the configuration for game elements, allowing for easy editing in the Unity Inspector.

### 1. `TowerData` (ScriptableObject)
Represents the static properties of a tower type.

- **Fields**:
  - `towerName` (string): The display name of the tower (e.g., "Thorns Rune").
  - `towerPrefab` (GameObject): The prefab to instantiate for this tower.
  - `cost` (int): The amount of mana required to build this tower.
  - `damage` (float): The damage dealt by a single attack.
  - `range` (float): The attack range of the tower.
  - `attackSpeed` (float): The time in seconds between attacks.
  - `specialAbility` (enum): The special ability of the tower (e.g., `None`, `Slow`, `AoE`, `Knockback`).
- **Validation**:
  - `cost`, `damage`, `range`, `attackSpeed` must be greater than 0.

### 2. `EnemyData` (ScriptableObject)
Represents the static properties of an enemy type.

- **Fields**:
  - `enemyName` (string): The name of the enemy.
  - `enemyPrefab` (GameObject): The prefab to instantiate for this enemy.
  - `health` (float): The starting health of the enemy.
  - `speed` (float): The movement speed of the enemy.
  - `manaOnKill` (int): The amount of mana awarded to the player when this enemy is killed.
- **Validation**:
  - `health`, `speed` must be greater than 0.
  - `manaOnKill` must be 0 or greater.

### 3. `WaveData` (ScriptableObject)
Represents the configuration for a single wave of enemies.

- **Fields**:
  - `waveName` (string): The name of the wave (e.g., "Wave 1").
  - `enemiesInWave` (List<EnemyData>): A list of the enemy types to spawn in this wave.
  - `enemyCount` (int): The total number of enemies to spawn in this wave.
  - `spawnInterval` (float): The time in seconds between each enemy spawn.
- **Validation**:
  - `enemyCount` and `spawnInterval` must be greater than 0.
  - `enemiesInWave` list cannot be empty.

## In-Game Objects (MonoBehaviours)

These are the scripts that will be attached to GameObjects in the scene.

### 1. `GameManager` (MonoBehaviour)
A singleton that manages the overall game state.

- **State**:
  - `playerMana` (int): The player's current mana.
  - `coreHealth` (int): The core's current health.
  - `currentWave` (int): The index of the current wave.
- **Events**:
  - `OnManaChanged`: Fired when the player's mana changes.
  - `OnCoreHealthChanged`: Fired when the core's health changes.
  - `OnWaveChanged`: Fired when a new wave starts.

### 2. `Tower` (MonoBehaviour)
The script attached to each individual tower instance.

- **State**:
  - `towerData` (TowerData): A reference to the ScriptableObject containing its base stats.
  - `target` (Enemy): The current enemy being targeted.
- **Behavior**:
  - Finds and targets enemies within its range.
  - Attacks its target based on its `attackSpeed`.
  - Applies special abilities.

### 3. `Enemy` (MonoBehaviour)
The script attached to each individual enemy instance.

- **State**:
  - `enemyData` (EnemyData): A reference to the ScriptableObject containing its base stats.
  - `currentHealth` (float): The current health of the enemy.
- **Behavior**:
  - Moves along the predefined waypoint path.
  - Damages the core when it reaches the end of the path.
  - Dies when its health reaches 0, awarding mana to the player.
