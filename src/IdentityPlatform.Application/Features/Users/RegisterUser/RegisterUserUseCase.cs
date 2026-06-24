using IdentityPlatform.Application.Abstractions;
using IdentityPlatform.Application.Common;
using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.Application.Features.Users.RegisterUser;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;

    public RegisterUserUseCase(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<RegisterUserResponse>> ExecuteAsync(
        RegisterUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var emailExists =
            await _userRepository.ExistsByEmailAsync(
                request.Email,
                cancellationToken);

        if (emailExists)
        {
            return Result<RegisterUserResponse>.Failure(
                "Email already registered.");
        }

        var user = new User(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        await _userRepository.AddAsync(
            user,
            cancellationToken);

        return Result<RegisterUserResponse>.Success(
            new RegisterUserResponse(user.Id));
    }
}