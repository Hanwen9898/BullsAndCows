using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            return CountBulls(guess);
        }

        private string CountBulls(string guess)
        {
            var guessDigits = guess.Split(' ');
            var secretDigits = secret.Split(' ');
            int countBulls = 0;
            int countCows = 0;
            for (var index = 0; index < secretDigits.Length; index++)
            {
                if (guessDigits[index] == secretDigits[index])
                {
                    countBulls++;
                }
                else if (guessDigits[index] != secretDigits[index] && secretDigits.Contains(guessDigits[index]))
                {
                    countCows++;
                }
            }

            return $"{countBulls}A{countCows}B";
        }
    }
}