﻿namespace BusinessLogic.Library.Services
{
    public interface ISha256HashService
    {
        string ComputeHashWithSalt(string password, string salt);
        string GetSalt();
        bool ValidateHash(string computed, string stored);
    }
}