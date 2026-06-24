using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityPlatform.Domain.ValueObjects;

public sealed class Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(
                "Password cannot be empty.",
                nameof(value));

        if (value.Length < 8)
            throw new ArgumentException(
                "Password must have at least 8 characters.",
                nameof(value));

        if (!value.Any(char.IsLetter))
            throw new ArgumentException(
                "Password must contain at least one letter.",
                nameof(value));

        if (!value.Any(char.IsDigit))
            throw new ArgumentException(
                "Password must contain at least one number.",
                nameof(value));

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
