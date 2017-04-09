using System;
using Newtonsoft.Json;
using NotesApi.Data;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Auth
{
    public class Auth : IAuth
    {
        private readonly IJWTToken _token;

        public Auth(IJWTToken token)
        {
            _token = token;
        }

        public string GenerateTokenForUser(UserEntity user)
        {
            Payload payload = new Payload();
            payload.ExpirationTime = payload.CreationTime.AddYears(1);
            payload.UserId = user.Id;
            payload.UserClaims = JsonConvert.DeserializeObject<Claims>(user.Claims);

            return _token.Build(payload);
        }

        public User GetUserFromToken(string token)
        {
            if (token.Length > 0)
            {
                User user = new User();
            
                Payload payload = _token.Parse(token);
                user.Id = payload.UserId;
                user.Claims = payload.UserClaims;

                return user;
            }

            return null;
        }
    }
}