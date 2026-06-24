using IdentityPlatform.Domain.Exceptions;
using IdentityPlatform.Domain.ValueObjects;

namespace IdentityPlatform.UnitTests.ValueObjects;

public class PasswordTests
{
    [Fact]
    public void Should_Create_Password_When_Value_Is_Valid()
    {
        // Arrange
        var value = "MinhaSenha123";

        // Act
        var password = new Password(value);

        // Assert
        Assert.Equal(value, password.Value);
    }

    [Fact]
    public void Should_Throw_Exception_When_Password_Is_Too_Short()
    {
        Assert.Throws<DomainException>(() =>
            new Password("123"));
    }

    [Fact]
    public void Should_Throw_Exception_When_Password_Has_No_Number()
    {
        Assert.Throws<DomainException>(() =>
            new Password("MinhaSenha"));
    }

    [Fact]
    public void Should_Throw_Exception_When_Password_Has_No_Letter()
    {
        Assert.Throws<DomainException>(() =>
            new Password("12345678"));
    }
}