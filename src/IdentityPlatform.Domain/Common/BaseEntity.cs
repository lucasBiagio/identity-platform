using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityPlatform.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
}