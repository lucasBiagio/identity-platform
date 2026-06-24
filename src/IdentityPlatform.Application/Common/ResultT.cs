using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityPlatform.Application.Common;

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(
        T value)
        : base(true, string.Empty)
    {
        Value = value;
    }

    private Result(
        string error)
        : base(false, error)
    {
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public new static Result<T> Failure(string error)
    {
        return new Result<T>(error);
    }
}
