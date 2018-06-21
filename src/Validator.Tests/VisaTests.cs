using System;
using Validator.Validators;
using Xunit;

namespace Validator.Tests
{
    public class VisaTests
    {
        private readonly VisaCardValidator visaValidator;

        public VisaTests()
        {
            this.visaValidator = new VisaCardValidator();
        }

        [Fact]
        public void ItShouldRejectCardsNotStartingWith4()
        {
            Assert.False(visaValidator.Match(new Card("512378687687678", "24234")));
        }

        [Theory]
        [InlineData("428276876")]
        [InlineData("4652389823")]
        [InlineData("4876876")]
        [InlineData("4876876")]
        public void ItShouldAcceptCardsStartingWith4(string number)
        {
            Assert.True(visaValidator.Match(new Card(number, "24234")));
        }

        [Fact]
        public void ItShouldFailIfNotLeap()
        {
            Assert.True(visaValidator.Match(new Card("412378687687678", "24234")));
        }
    }
}
