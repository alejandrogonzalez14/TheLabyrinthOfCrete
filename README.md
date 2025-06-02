# The Labyrinth of Crete

An **interactive cooperative maze game** built in Unity, where two players step into the mythic roles of **Theseus** and **Ariadne**. Collaborate, solve puzzles, and face the legendary **Minotaur** in the heart of the labyrinth.

## Overview

This project was developed as part of the *Interactive Systems* subject. It combines **team-based gameplay**, **puzzle-solving mechanics**, and an **action-based boss fight** in a mythological setting. Players must rely on communication and coordination to survive the maze and defeat the monster.

## The Myth Behind the Game

The game is inspired by the Greek myth of **Theseus and the Minotaur**, a classic tale of heroism and cunning. According to legend, the Minotaur, a fearsome creature, half-man and half-bull, was imprisoned at the centre of a vast labyrinth built by Daedalus for King Minos of Crete. To end the suffering of his people, the Athenian prince Theseus volunteers to enter the labyrinth and kill the beast.

Before entering, Theseus receives help from Ariadne, the king’s daughter, who gives him a ball of thread to trace his path. Thanks to her guidance, Theseus is able to navigate the maze, slay the Minotaur, and escape, becoming a legendary hero.

Our game brings this myth to life as a cooperative journey where Theseus and Ariadne must work together to overcome challenges, find their way through the labyrinth, and defeat the Minotaur in a final confrontation.

> Learn more about the myth: [Theseus and the Minotaur - GreekMythology.com](https://www.greekmythology.com/Myths/Heroes/Theseus/theseus.html)

## Core Gameplay

- **Co-op Mechanics**: Two players (Theseus and Ariadne) must cooperate to progress, opening doors for each other and collecting rocks.
- **Maze Navigation**: Inspired by the Labyrinth of Crete, the maze requires exploration, coordination, and timing.
- **Boss Battle**: After reaching the centre, players enter a new scene where they face the **Minotaur**.
- **Combat System**: Defeat the Minotaur by throwing rocks; players must swipe a horizontal tracker at high speed to land a hit.
- **Shared Lives**: The players have a **shared pool of 3 lives**. If all are lost, the game ends.
- **Timed Challenge**: Defeat the Minotaur before the timer runs out.

## How to play
The game is primarily designed for use in an interactive tracking room equipped with multiple motion trackers. Players control their characters by physically moving around with their trackers; the corresponding in-game character will follow their position in real time. The system ensures that characters cannot walk through walls, and if a player moves too far from their character, the movement will be restricted to preserve tracking coherence. In the final scene, located at the centre of the maze, players must defeat the Minotaur by swinging their tracker horizontally at high speed to throw rocks as an attack.

For users playing on a regular computer, the game is also fully functional with keyboard controls. Movement is handled using the WASD keys, though only one character can be controlled at a time. Players can switch control between Theseus and Ariadne by pressing the 1 or 2 keys, respectively. During the final boss fight, rocks can be thrown at the Minotaur by pressing the spacebar.

Keep in mind that rocks are limited, so players must plan their actions carefully to succeed. Strategic collaboration and efficient use of resources are essential to defeat the Minotaur before time runs out.

## Requirements

- Unity 2020.2 or later
- 2 controllers (or keyboard/gamepad split input)
- Windows/macOS build support

## License

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](./LICENSE)

This project's source code is licensed under the [MIT License](./LICENSE).

> [!NOTE]
> Third-party 3D assets used in this project are licensed separately.  
> Please refer to [ATTRIBUTIONS.md](./ATTRIBUTIONS.md) for full details and usage terms.

## Installation & Setup

## Credits
This project includes third-party 3D assets.
See [ATTRIBUTIONS.md](./ATTRIBUTIONS.md) for full credits and licensing information.
