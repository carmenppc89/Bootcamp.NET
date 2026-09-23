# Cards and Decks — *CarmenPPerez_CartasYBarajas*

## Goal
Model real-world entities (`Carta`/Card, `Baraja`/Deck) as classes, applying encapsulation and collection-style operations.

## Description
Console application that simulates a full 52-card deck (4 suits × 13 ranks). From an interactive menu, the user can shuffle the deck, draw the top card, draw a card at a specific position, or draw a random card.

## Features
- `AñadirBarajaEntera()` — generates all 52 cards of the deck.
- `Barajar()` — shuffles the cards using a random-extraction shuffle algorithm.
- `Robar()` / `RobarPosN()` / `RobarAlAzar()` — different ways to draw a card from the deck.
- `PrintBaraja()` — prints the current state of the deck in a table format.

## Concepts practiced
- Encapsulated classes and properties (`Carta`, `Baraja`)
- Enumerations (`enum ePalos`)
- `List<T>` and LINQ (`Count()`)
- Random numbers (`Random`)

## ▶️ How to run
1. Open `CarmenPPerez_CartasYBarajas/CarmenPPerez_CartasYBarajas.sln`.
2. Press `Ctrl+F5` (Start Without Debugging) or `F5`.

---
⬅️ [Back to Classes](../)
