using IdentityPlatform.Application.Abstractions;
using IdentityPlatform.Application.Common;
using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.Application.Features.Users.RegisterUser;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserUseCase(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<RegisterUserResponse>> ExecuteAsync(
        RegisterUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var emailExists = await _userRepository.ExistsByEmailAsync(
            request.Email,
            cancellationToken);

        if (emailExists)
        {
            return Result<RegisterUserResponse>.Failure(
                "Email already registered.");
        }

        var passwordHash = _passwordHasher.Hash(request.Password);

        var user = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            passwordHash);

        await _userRepository.AddAsync(
            user,
            cancellationToken);

        return Result<RegisterUserResponse>.Success(
            new RegisterUserResponse(user.Id));
    }
}