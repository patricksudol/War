# War Card Game
A .NET Core Console application for the card game: War.

## Rules
1. Each player will be dealt half of the cards, face down, from a shuffled deck.
2. On each turn the player will take the top card in their deck and present it face up.
3. The player with the higher card gets both cards dealt and places it to the bottom of their deck.
4. If both players presents a card of the same value, they go to "War". They put down three more cards, face down,
and the fourth card face up. Whoever has the higher card wins all the cards dealt in that turn and places it to their deck.
5. The game is over when a player runs out of cards or does not have enough to go to "War".

## Installation
1. Git clone the following Github repository:
```Bash
git@github.com:patricksudol/War.git
```
2. Install .NET Core (Developed on 3.1 but should work on older versions).
```Bash
https://dotnet.microsoft.com/download
```
3. Run the command:
```Bash
dotnet run
```