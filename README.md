# Mastermind Console Game (C#)

A C# console version of the classic **Mastermind** game.

---

## Game Rules

- The secret code is **4 distinct digits**, chosen from 0–8 (total 9 possible values).
- You have a limited number of attempts (default: **10**) to guess the secret code.
- After each guess, you get feedback:
  - **Well placed pieces:** digits correct in value and position.
  - **Misplaced pieces:** digits correct in value but wrong position.
- Input must be 4 distinct digits (`0-8`). Invalid input shows "Wrong input!".
- The game ends when you guess the code or run out of attempts.
- Secret code and attempt count can be provided as command-line arguments.

---

## How to Build & Run

**Build:**
```sh
dotnet build
or (for a single .cs file):

sh
Copy
Edit
csc Game.cs
Run:

sh
Copy
Edit
./Game.exe
or

sh
Copy
Edit
dotnet run --project Game.csproj
Usage Examples
Default (random code, 10 attempts):

sh
Copy
Edit
./Game.exe
With secret code and attempts specified:

sh
Copy
Edit
./Game.exe -c 0123 -t 12
-c [CODE]: Set the secret code (must be 4 distinct digits 0–8)

-t [ATTEMPTS]: Set the number of attempts

Example Game Session
yaml
Copy
Edit
Will you find the secret code?
Please enter a valid guess
---
Round 0
>1456
Well placed pieces: 0
Misplaced pieces: 1
---
Round 1
>tata
Wrong input!
---
Round 2
>0123
Congratz! You did it!
```

## Class Structure

Code: Handles secret code generation and validation.

Player: Handles user input and validation.

Game: Manages game rounds, scoring, and logic.

Program: Entry point, handles command-line arguments.

