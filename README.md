# SpaceBattle Demo

SpaceBattle is a **2D space arcade demo for PC**, developed with **Unity in C#**. The player controls a spaceship, eliminates enemies and faces a final boss in each of the two levels.

## Features

- Two levels with enemies and final bosses.
- Keyboard-controlled spaceship movement.
- Mouse-controlled shooting.
- Enemy projectiles and collision handling.
- Lives system with interface indicators.
- Spaceship appearance changes based on remaining lives.
- Score updated during gameplay.
- Explosion effects.
- Victory and defeat screens, with the option to restart.
- Browser-playable demo.

## Controls

- **Arrow keys or WASD**: move the spaceship.
- **Left mouse button**: shoot.

## Repository structure

```text
SpaceBattleDemo/
├── Assets/             Scenes, scripts, prefabs and graphical assets
│   ├── Scenes/         Scenes for the two levels
│   └── Script/         C# source code
├── Packages/           Unity dependency configuration
├── ProjectSettings/    Project settings
├── docs/               Web demo files
└── README.md
```

## Opening the project

Requires **Unity 2021.3.11f1**.

1. Clone the repository or download and extract the ZIP archive.
2. Add the project to Unity Hub by selecting the folder containing `Assets`, `Packages` and `ProjectSettings`.
3. Open the project with Unity 2021.3.11f1.
4. Wait for the assets to finish importing.
5. Open the scene `Assets/Scenes/First_Level.unity`.
6. Press **Play** to start the game in the Editor.

The second scene is `Assets/Scenes/Second_Level.unity`.

## Game logic

Spaceship movement uses the horizontal and vertical input axes. Projectiles move in the firing direction and are removed when they move beyond the designated area.

Collisions handle enemy hits, damage to the spaceship and explosion effects. The score is updated when enemies are destroyed and when the boss is hit.

The boss can take damage after the remaining enemies have been eliminated. The number of hits required to destroy it varies between the two levels.

The game manager controls the victory and defeat screens, restarting and transitions between scenes.

## Preview

[Play the demo in your browser](https://fanzio.github.io/SpaceBattleDemo/)
