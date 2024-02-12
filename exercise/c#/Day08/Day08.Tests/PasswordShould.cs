using Xunit;

namespace Day08.Tests;

public class PasswordShould
{
    // TODO Contains at least 8 characters
    [Fact]
    public void Have_at_least_8_characters()
        => Password.IsValid("12345678").Should().BeTrue();

    // TODO Contains at least one capital letter
    // TODO Contains at least one lowercase letter
    // TODO Contains at least a number
    // TODO Contains at least a special character in this list . * # @ $ % &.
    // TODO Any other characters are not authorized.
}