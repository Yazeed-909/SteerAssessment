using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteerAssessment
{
    // Handles player input and validation
    public class Player
    {
        public string GetGuess(int length, int colorCount)
        {
            string input = Console.ReadLine();
            if (input == null)
                return null;
            input = input.Trim();
            return input;
        }

        public bool IsValidGuess(string guess, int length, int colorCount)
        {
            return guess.Length == length &&
                guess.All(c => c >= '0' && c < '0' + colorCount) &&
                guess.Distinct().Count() == length;
        }
    }
}
