namespace BPSample.Domain.UnitTests.Shared
{
    using System;
    using BPSample.Domain.Shared;
    using FluentAssertions;
    using Xunit;

    public class ChiNumberTests
    {
        [Fact]
        public void ShouldCreateWithValidChiNumber()
        {
            var chi = new ChiNumber("2212890699");

            chi.Value.Should().Be("2212890699");
        }

        [Fact]
        public void ShouldThrowIfChiNumberNull()
        {
            FluentActions.Invoking(() => new ChiNumber(null))
                .Should().ThrowExactly<ArgumentNullException>("null").Which.ParamName.Should().Be("value");

            FluentActions.Invoking(() => new ChiNumber(""))
                .Should().ThrowExactly<ArgumentException>("empty").Which.ParamName.Should().Be("value");

            FluentActions.Invoking(() => new ChiNumber(" "))
                .Should().ThrowExactly<ArgumentException>("whitespace").Which.ParamName.Should().Be("value");
        }

        [Theory]
        [InlineData("1")]
        [InlineData("11111111111")]
        [InlineData("1234567890")]
        public void ShouldThrowWithInvalidChiNumber(string chi)
        {
            FluentActions.Invoking(() => new ChiNumber(chi))
                .Should().ThrowExactly<ArgumentException>(chi).Which.ParamName.Should().Be("value");

        }
    }
}
