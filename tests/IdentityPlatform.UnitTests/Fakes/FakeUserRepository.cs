using IdentityPlatform.Application.Abstractions;
using IdentityPlatform.Domain.Entities;

namespace IdentityPlatform.UnitTests.Fakes;

public class FakeUserRepository : IUserRepository
{
    private readonly List<User> _users = [];

    public Task AddAsync(
        User user,
        CancellationToken cancellationToken = default)
    {
        _users.Add(user);

        return Task.CompletedTask;
    }

    public Task<bool> ExistsByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            _users.Any(x => x.Email.Value == email));
    }

    public int Count => _users.Count;
}