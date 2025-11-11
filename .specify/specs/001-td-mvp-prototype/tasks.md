# Tasks: Tower Defense MVP

**Input**: Design documents from `/specs/001-td-mvp-prototype/`

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic scene/asset structure.

- [X] T001 [P] Create folder structure in `Assets/`: `_Project`, `Scenes`, `Scripts`, `Prefabs`, `ScriptableObjects`.
- [X] T002 [P] Create 3 primitive prefabs for enemies (e.g., Cube, Sphere, Capsule) in `Assets/Prefabs/Enemies/`.
- [X] T003 [P] Create 3 primitive prefabs for towers (e.g., different colored materials) in `Assets/Prefabs/Towers/`.
- [X] T004 Set up the `Forest01` scene in `Assets/Scenes/` with a simple ground plane/tilemap.
- [X] T005 Create 6-8 empty GameObject waypoints for the enemy path in the `Forest01` scene.
- [X] T006 Create designated empty GameObjects for tower placement spots in the `Forest01` scene.

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core managers and data structures that all other systems depend on.

- [X] T007 Create `GameManager.cs` script in `Assets/Scripts/Managers/` to handle game state (mana, core health, wave number).
- [X] T008 Create `UIManager.cs` script in `Assets/Scripts/Managers/` to manage UI display.
- [X] T009 Set up a basic UI Canvas in the `Forest01` scene with text elements for Mana, Core Health, and Wave Number.
- [X] T010 [P] Create `TowerData.cs` ScriptableObject script in `Assets/Scripts/Data/`.
- [X] T011 [P] Create `EnemyData.cs` ScriptableObject script in `Assets/Scripts/Data/`.
- [X] T012 [P] Create `WaveData.cs` ScriptableObject script in `Assets/Scripts/Data/`.
- [X] T013 Create initial ScriptableObject assets for the 3 enemy types and 3 tower types in `Assets/ScriptableObjects/`.

---

## Phase 3: User Story 1 - Core Gameplay Loop (Priority: P1) 🎯 MVP

**Goal**: Player can place a basic tower to defend against a wave of enemies.

**Independent Test**: Start the game, see one wave of enemies move along the path, and place one tower to shoot at them.

- [X] T014 [US1] Implement `Enemy.cs` script in `Assets/Scripts/Gameplay/` for health and taking damage.
- [X] T015 [US1] Implement `EnemyMovement.cs` script in `Assets/Scripts/Gameplay/` to move an enemy along the waypoints.
- [X] T016 [US1] Create `WaveSpawner.cs` script in `Assets/Scripts/Gameplay/` to spawn waves based on `WaveData` ScriptableObjects.
- [X] T017 [US1] Implement `Tower.cs` base script in `Assets/Scripts/Towers/` with logic for finding and targeting enemies.
- [X] T018 [US1] Implement `TowerPlacement.cs` script in `Assets/Scripts/Gameplay/` to handle placing towers on designated spots.
- [X] T019 [US1] Connect `GameManager` to handle spending mana when a tower is placed.
- [X] T020 [US1] Connect `UIManager` to display the initial game state from `GameManager`.

---

## Phase 4: User Story 2 - Tower Variety (Priority: P2)

**Goal**: Player can use three different tower types with unique abilities.

**Independent Test**: Build each of the three tower types and observe their special abilities (Slow, AoE, Knockback) affecting enemies.

- [X] T021 [P] [US2] Create `ThornsTower.cs` script in `Assets/Scripts/Towers/` that inherits from `Tower` and applies a slow effect.
- [X] T022 [P] [US2] Create `FlamesTower.cs` script in `Assets/Scripts/Towers/` that inherits from `Tower` and deals AoE damage.
- [X] T023 [P] [US2] Create `WindsTower.cs` script in `Assets/Scripts/Towers/` that inherits from `Tower` and applies a knockback force.
- [X] T024 [US2] Update `TowerPlacement.cs` to allow selection and placement of the different tower types.

---

## Phase 5: User Story 3 - Win/Loss Conditions (Priority: P3)

**Goal**: The game has a clear start and end, with victory or defeat outcomes.

**Independent Test**: Win the game by defeating all 5 waves. Lose the game by letting the core's health reach zero.

- [X] T025 [US3] Implement logic in `EnemyMovement.cs` to damage the core when an enemy reaches the final waypoint.
- [X] T026 [US3] Implement logic in `GameManager.cs` to track the number of cleared waves.
- [X] T027 [US3] Implement win condition in `GameManager.cs` when all 5 waves are cleared.
- [X] T028 [US3] Implement loss condition in `GameManager.cs` when core health reaches zero.
- [X] T029 [US3] Update `UIManager.cs` to display "Victory" or "Defeat" UI panels based on game outcome.

---

## Phase N: Polish & Cross-Cutting Concerns

**Purpose**: Final improvements and validation.

- [X] T030 [P] Code cleanup and refactoring across all new scripts.
- [X] T031 Performance testing to ensure the game runs at 60 FPS with 20-30 enemies.
- [X] T032 Final review of all created assets and scene configurations.
- [X] T033 Validate that all tasks are complete and the game meets all acceptance criteria from the `spec.md`.
