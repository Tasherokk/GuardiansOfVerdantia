# Feature Specification: Tower Defense MVP Prototype

**Feature Branch**: `001-td-mvp-prototype`
**Created**: 2025-11-12
**Status**: Draft
**Input**: User description: "Проект: Guardians of Verdantia — Unity 2D Tower Defense (минимальный прототип). Цель: быстрый MVP, который запускается из одной сцены, имеет 5 волн, 3 башни, 3 врага, простейший баланс и HUD."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Core Gameplay Loop (Priority: P1)
As a player, I want to start the game, see waves of enemies spawn and move towards my core, and be able to place towers on designated spots to defend it, so that I can experience the basic tower defense gameplay.

**Why this priority**: This is the fundamental gameplay loop and the absolute minimum for a playable prototype.

**Independent Test**: The game can be launched, a wave can be started, and a basic tower can be placed to shoot at an enemy.

**Acceptance Scenarios**:
1. **Given** the game has started, **When** the first wave begins, **Then** enemies spawn at the start of the path and move towards the core.
2. **Given** I have enough mana, **When** I select a tower and a valid placement spot, **Then** a tower is built on that spot.

---

### User Story 2 - Tower Variety (Priority: P2)
As a player, I want to be able to build three different types of towers (Thorns, Flames, Winds), each with a unique ability, so that I can use different strategies to defeat enemies.

**Why this priority**: Introduces strategic choice, which is a core element of the tower defense genre.

**Independent Test**: Each of the three tower types can be built and their unique abilities (slow, AoE, knockback) can be observed to function correctly on an enemy.

**Acceptance Scenarios**:
1. **Given** I have built a Thorns tower, **When** an enemy is in range, **Then** the tower attacks the enemy and applies a slow effect.
2. **Given** I have built a Flames tower, **When** it attacks an enemy, **Then** it deals damage in a small area of effect around the target.
3. **Given** I have built a Winds tower, **When** it attacks an enemy, **Then** the enemy is knocked back along its path.

---

### User Story 3 - Win/Loss Conditions (Priority: P3)
As a player, I want the game to have clear win and loss conditions, so that there is a goal to strive for and a penalty for failure.

**Why this priority**: Provides a clear objective and completes the gameplay loop with a definitive outcome.

**Independent Test**: The game can be won by clearing all waves, and it can be lost by letting the core's health drop to zero.

**Acceptance Scenarios**:
1. **Given** I am on the final (5th) wave, **When** I defeat the last enemy, **Then** a "Victory" message is displayed.
2. **Given** the core is being attacked, **When** its health reaches 0, **Then** a "Defeat" message is displayed.

---

### Edge Cases
- What happens if the player tries to build a tower with insufficient mana? (Expected: Action is blocked, feedback is provided).
- What happens if an enemy is knocked back to the start of the path? (Expected: It continues along the path normally).
- How does the game handle a large number of enemies on screen at once? The game should handle 20-30 active enemies on screen simultaneously while maintaining 60 FPS.

## Requirements *(mandatory)*

### Functional Requirements
- **FR-001**: The game MUST be a single Unity scene named `Forest01`.
- **FR-002**: The scene MUST contain a predefined enemy path consisting of 6-8 waypoint objects.
- **FR-003**: The game MUST spawn 5 distinct waves of enemies.
- **FR-004**: There MUST be 3 types of enemies, represented by primitive prefabs (e.g., circle, square, triangle).
- **FR-005**: There MUST be 3 types of towers (Thorns, Flames, Winds) with unique abilities (single-target slow, AoE damage, knockback).
- **FR-006**: The player MUST have a "Mana" resource used for building towers.
- **FR-007**: The player MUST gain a fixed amount of Mana after each wave and a small amount for each enemy killed.
- **FR-008**: The UI MUST display the player's current Mana, the current wave number, and the core's remaining health.
- **FR-009**: The game MUST end with a victory condition (all 5 waves cleared) or a defeat condition (core health reaches 0).
- **FR-010**: The player MUST only be able to place towers on pre-marked, designated locations.
- **FR-011**: The core MUST have a specific number of lives/health points. The core should have 10 lives/health points.

### Key Entities *(include if feature involves data)*
- **Tower**: Represents a defensive unit. Attributes: Type (Thorns, Flames, Winds), Cost, Damage, Range, Special Ability (Slow, AoE, Knockback).
- **Enemy**: Represents an attacker. Attributes: Type, Health, Speed, Mana Reward on kill.
- **Wave**: A configuration of enemies to be spawned over a period of time.
- **Core**: The base to be defended. Attributes: Health.
- **Player**: Represents the user's state. Attributes: Mana.

## Success Criteria *(mandatory)*

### Measurable Outcomes
- **SC-001**: The `Forest01` scene MUST launch and the game MUST be playable from the first wave to a win/loss screen without crashing.
- **SC-002**: All 5 enemy waves MUST spawn sequentially as designed.
- **SC-003**: The player MUST be able to build and see the effects of all 3 unique tower types.
- **SC-004**: Enemies MUST correctly follow the defined waypoint path and damage the core upon reaching the end.
- **SC-005**: The game MUST consistently maintain a frame rate of 60 FPS or higher during gameplay on the target hardware.
- **SC-006**: The UI for Mana, Wave Number, and Core Health MUST accurately reflect the game state in real-time.
- **SC-007**: A clear "Victory" or "Defeat" outcome MUST be presented to the player upon meeting the respective conditions.
