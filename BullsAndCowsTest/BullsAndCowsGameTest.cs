using BullsAndCows;
using Moq;
using System.Net.Sockets;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 3 4")]
        [InlineData("5 2 3 4", "5 2 3 4")]
        [InlineData("5 2 3 7", "5 2 3 7")]

        public void Should_return_4A0B_When_given_the_guess_digits_are_same_with_secret_number(string secret, string guessDigits)
        {
            var mocksecretGenerator = new Mock<SecretGenerator>();
            mocksecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mocksecretGenerator.Object);
            var guessResult = game.Guess(guessDigits);
            Assert.Equal("4A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 7")]
        [InlineData("5 2 3 4", "5 2 7 9")]
        [InlineData("5 2 3 7", "5 2 4 1")]
        public void Should_return_2A0B_When_given_the_guess_digits_having_2_correct_with_secret_number(string secret, string guessDigits)
        {
            var mocksecretGenerator = new Mock<SecretGenerator>();
            mocksecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mocksecretGenerator.Object);
            var guessResult = game.Guess(guessDigits);
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 3")]
        [InlineData("5 2 3 4", "5 2 4 9")]
        [InlineData("5 2 3 7", "5 2 4 3")]
        public void Should_return_2A1B_When_given_the_guess_digits_having_2_correct_value_position_and_1_position_with_secret_number(string secret, string guessDigits)
        {
            var mocksecretGenerator = new Mock<SecretGenerator>();
            mocksecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mocksecretGenerator.Object);
            var guessResult = game.Guess(guessDigits);
            Assert.Equal("2A1B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "5 6 7 8")]
        [InlineData("5 2 3 4", "1 7 8 9")]
        [InlineData("5 2 3 7", "6 8 4 1")]
        public void Should_return_0A0B_When_given_the_guess_digits_having_no_correct_with_secret_number(string secret, string guessDigits)
        {
            var mocksecretGenerator = new Mock<SecretGenerator>();
            mocksecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mocksecretGenerator.Object);
            var guessResult = game.Guess(guessDigits);
            Assert.Equal("0A0B", guessResult);
        }
    }
}
