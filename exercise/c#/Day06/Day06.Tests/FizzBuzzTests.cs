using FluentAssertions;
using Xunit;

namespace Day06.Tests;

public class FizzBuzzTests
{
    #region "Normal" numbers

    [Theory]
    [InlineData(1, "1")]
    [InlineData(67, "67")]
    [InlineData(82, "82")]
    public void Returns_The_Given_Number_For_(int input, string output) => FizzBuzz.Convert(input).Should().Be(output);
    
    #endregion

    #region Fizz

    [Theory]
    [InlineData(3)]
    [InlineData(66)]
    [InlineData(99)]
    public void Returns_Fizz_For_(int input) => FizzBuzz.Convert(input).Should().Be("Fizz");

    #endregion

    #region Buzz

    [Fact]
    public void Returns_Buzz_For_5() => FizzBuzz.Convert(5).Should().Be("Buzz");

    [Fact]
    public void Returns_Buzz_For_50() => FizzBuzz.Convert(50).Should().Be("Buzz");

    [Fact]
    public void Returns_Buzz_For_85() => FizzBuzz.Convert(85).Should().Be("Buzz");

    #endregion

    #region FizzBuzz

    [Fact]
    public void Returns_FizzBuzz_For_15() => FizzBuzz.Convert(15).Should().Be("FizzBuzz");

    [Fact]
    public void Returns_FizzBuzz_For_30() => FizzBuzz.Convert(30).Should().Be("FizzBuzz");

    [Fact]
    public void Returns_FizzBuzz_For_45() => FizzBuzz.Convert(45).Should().Be("FizzBuzz");

    #endregion

    #region Failures

    [Fact]
    public void Throws_An_Exception_For_0()
    {
        var act = () => FizzBuzz.Convert(0);
        act.Should().Throw<OutOfRangeException>();
    }

    [Fact]
    public void Throws_An_Exception_For_101()
    {
        var act = () => FizzBuzz.Convert(101);
        act.Should().Throw<OutOfRangeException>();
    }

    [Fact]
    public void Throws_An_Exception_For_Minus_1()
    {
        var act = () => FizzBuzz.Convert(-1);
        act.Should().Throw<OutOfRangeException>();
    }

    #endregion
}