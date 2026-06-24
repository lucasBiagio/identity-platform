using System;
using System.Collections.Generic;
using System.Text;
using IdentityPlatform.Domain.Exceptions;

namespace IdentityPlatform.Domain.ValueObjects;

public sealed class Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(
                "Password cannot be empty.");

        if (value.Length < 8)
            throw new DomainException(
                "Password must have at least 8 characters.");

        if (!value.Any(char.IsLetter))
            throw new DomainException(
                "Password must contain at least one letter.");

        if (!value.Any(char.IsDigit))
            throw new DomainException(
                "Password must contain at least one number.");

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
