using System;
using System.Collections.Generic;
using System.Text;

using IdentityPlatform.Domain.Common;

namespace IdentityPlatform.Domain.Entities;

public class Role : BaseEntity
{
    private readonly List<Permission> _permissions = [];

    public IReadOnlyCollection<Permission> Permissions =>
        _permissions.AsReadOnly();
    public string Name { get; private set; } = string.Empty;

    public void AddPermission(Permission permission)
    {
        if (_permissions.Any(x => x.Id == permission.Id))
            return;

        _permissions.Add(permission);
    }
    private Role()
    {
    }

    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
