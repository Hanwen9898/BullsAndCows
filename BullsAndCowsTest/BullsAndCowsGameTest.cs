using BullsAndCows;
using Moq;
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

        [Fact]
        public void Should_return_4A0B_When_given_the_digits_are_same_with_secret_number()
        {
            var mocksecretGenerator = new Mock<SecretGenerator>();
            mocksecretGenerator.Setup(generator => generator.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mocksecretGenerator.Object);
            var guessResult = game.Guess("1 2 3 4");
            Assert.Equal("4A0B", guessResult);
        }
    }
}
