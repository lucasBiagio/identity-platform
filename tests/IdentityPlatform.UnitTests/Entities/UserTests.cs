using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.UnitTests.Entities;

public class UserTests
{
    [Fact]
    public void Should_Assign_Role_To_User()
    {
        // Arrange
        var user = new User(
            "Lucas",
            "Biagio",
            "lucas@email.com",
            "hash");

        var role = new Role("Admin");

        // Act
        user.AssignRole(role);

        // Assert
        Assert.Single(user.Roles);
    }

    [Fact]
    public void Should_Not_Assign_Duplicate_Role()
    {
        // Arrange
        var user = new User(
            "Lucas",
            "Biagio",
            "lucas@email.com",
            "hash");

        var role = new Role("Admin");

        // Act
        user.AssignRole(role);
        user.AssignRole(role);

        // Assert
        Assert.Single(user.Roles);
    }
}