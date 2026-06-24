using System;
using System.Collections.Generic;
using System.Text;

using IdentityPlatform.Domain.Common;

namespace IdentityPlatform.Domain.Entities;

public class Permission : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    private Permission()
    {
    }

    public Permission(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
