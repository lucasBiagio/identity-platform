using System;
using System.Collections.Generic;
using System.Text;

using IdentityPlatform.Domain.Common;

namespace IdentityPlatform.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    private Role()
    {
    }

    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
