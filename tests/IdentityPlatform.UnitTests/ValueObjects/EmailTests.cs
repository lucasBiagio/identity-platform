using IdentityPlatform.Domain.Exceptions;
using IdentityPlatform.Domain.ValueObjects;

namespace IdentityPlatform.UnitTests.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Should_Create_Email_When_Value_Is_Valid()
    {
        
        var value = "lucas@email.com";
        
        var email = new Email(value);
        
        Assert.Equal(value, email.Value);
    }

    [Fact]
    public void Should_Throw_Exception_When_Email_Is_Invalid()
    {
        // Arrange
        var value = "email-invalido";

        // Act & Assert
        Assert.Throws<DomainException>(() =>
            new Email(value));
    }
}