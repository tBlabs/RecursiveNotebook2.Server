using System;
using NotesApi.Data;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Auth
{ 
    public interface IAuth
    {
        string GenerateTokenForUser(UserEntity user);
        User GetUserFromToken(string token);
    }
}