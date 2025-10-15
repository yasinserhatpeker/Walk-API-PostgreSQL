using System;
using Microsoft.AspNetCore.Identity;

namespace MyApp.Repositories.Interfaces;

public interface ITokenRepository
{
    string CreateJWTToken(IdentityUser user, List<string> roles);
}
