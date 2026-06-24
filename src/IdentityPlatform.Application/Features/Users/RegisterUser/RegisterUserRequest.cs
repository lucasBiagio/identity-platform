using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityPlatform.Application.Features.Users.RegisterUser;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
