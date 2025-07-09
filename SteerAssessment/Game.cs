using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SteerAssessment
{
    public class Game
    {
        private readonly int codeLength = 4;
        private readonly int colorCount = 9;
        private readonly int maxRounds;
        private Code secretCode;
        private Player player;

        public Game(string code = null, int rounds = 10)
        {
            maxRounds = rounds;
            secretCode = new Code(codeLength, colorCount, code);
            player = new Player();
        }

        public void Start()
        {
            Console.WriteLine("Will you find the secret code?");
            Console.WriteLine("Please enter a valid guess");

            int round = 0;
            while (round < maxRounds)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Round {round}");
                Console.Write(">");

                string guess = player.GetGuess(codeLength, colorCount);

                // Handle EOF (Ctrl+D or Ctrl+Z)
                if (guess == null)
                {
                    Console.WriteLine();
                    break;
                }

                if (!player.IsValidGuess(guess, codeLength, colorCount))
                {
                    Console.WriteLine("Wrong input!");
                    continue;
                }

                int wellPlaced = CountWellPlaced(secretCode.Value, guess);
                int misplaced = CountMisplaced(secretCode.Value, guess);

                if (wellPlaced == codeLength)
                {
                    Console.WriteLine("Congratz! You did it!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Well placed pieces: {wellPlaced}");
                    Console.WriteLine($"Misplaced pieces: {misplaced}");
                    round++;
                }
            }
        }

        private int CountWellPlaced(string code, string guess)
        {
            int count = 0;
            for (int i = 0; i < codeLength; i++)
                if (code[i] == guess[i]) count++;
            return count;
        }

        private int CountMisplaced(string code, string guess)
        {
            // Well-placed positions should not be counted as misplaced
            var codeChars = code.ToCharArray();
            var guessChars = guess.ToCharArray();
            int misplaced = 0;
            var codeUsed = new bool[codeLength];
            var guessUsed = new bool[codeLength];

            // First mark well-placed
            for (int i = 0; i < codeLength; i++)
            {
                if (guessChars[i] == codeChars[i])
                {
                    codeUsed[i] = true;
                    guessUsed[i] = true;
                }
            }
            // Now count misplaced
            for (int i = 0; i < codeLength; i++)
            {
                if (guessUsed[i]) continue;
                for (int j = 0; j < codeLength; j++)
                {
                    if (!codeUsed[j] && guessChars[i] == codeChars[j])
                    {
                        misplaced++;
                        codeUsed[j] = true;
                        break;
                    }
                }
            }
            return misplaced;
        }
    }
}