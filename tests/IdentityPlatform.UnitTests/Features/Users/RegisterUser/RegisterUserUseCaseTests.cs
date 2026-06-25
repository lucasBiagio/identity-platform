using IdentityPlatform.Application.Features.Users.RegisterUser;
using IdentityPlatform.UnitTests.Fakes;

namespace IdentityPlatform.UnitTests.Features.Users.RegisterUser;

public class RegisterUserUseCaseTests
{
    [Fact]
    public async Task Should_Register_User()
    {
        // Arrange
        var repository = new FakeUserRepository();

        var passwordHasher = new FakePasswordHasher();

        var useCase = new RegisterUserUseCase(
            repository,
            passwordHasher);

        var request = new RegisterUserRequest(
            "Lucas",
            "Biagio",
            "lucas@email.com",
            "MinhaSenha123");

        // Act
        var result = await useCase.ExecuteAsync(request);

        // Assert
        Assert.True(result.IsSuccess);

        Assert.Equal(1, repository.Count);
    }
}