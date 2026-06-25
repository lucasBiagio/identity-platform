using IdentityPlatform.Application.Abstractions;

namespace IdentityPlatform.UnitTests.Fakes;

public class FakePasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return $"HASH::{password}";
    }

    public bool Verify(string password, string passwordHash)
    {
        return passwordHash == $"HASH::{password}";
    }
}