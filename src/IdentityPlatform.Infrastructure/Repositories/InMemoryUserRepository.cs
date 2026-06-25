using IdentityPlatform.Application.Abstractions;
using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.Infrastructure.Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public Task<bool> ExistsByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        var exists = _users.Any(x =>
            x.Email.Value == email.ToLowerInvariant());

        return Task.FromResult(exists);
    }

    public Task AddAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        _users.Add(user);

        return Task.CompletedTask;
    }
}