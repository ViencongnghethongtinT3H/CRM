﻿namespace FDS.CRM.Infrastructure.Identity;

public class PasswordHasher : IPasswordHasher
{
    public bool VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        return new PasswordHasher<User>().VerifyHashedPassword(user, hashedPassword, providedPassword) != PasswordVerificationResult.Failed;
    }
}
