using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.Application.Abstractions;

public interface IUserRepository
{
    Task<bool> ExistsByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        User user,
        CancellationToken cancellationToken = default);
}