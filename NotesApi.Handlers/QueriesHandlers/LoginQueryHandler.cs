using NotesApi.Auth;
using NotesApi.Data;
using NotesApi.Data.Repositories;
using NotesApi.Models;
using System;
using Newtonsoft.Json;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, string>
    {
        private readonly IAuth _auth;
        private readonly IUsersRepo _users;

        public LoginQueryHandler(IAuth auth, IUsersRepo users)
        {
            _auth = auth;
            _users = users;
        }

        public string Handle(LoginQuery query, IWebHydraContext context)
        {
            Console.WriteLine($"Loging with '{query.Email}' and '{query.Password}'...");

            // TODO validation

            UserEntity userEntity = _users.GetByEmail(query.Email);
            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }

            if (userEntity.Password != query.Password)
            {
                throw new WrongPasswordException();
            }

            User user = new User();
            user.Id = userEntity.Id;
            user.Claims = JsonConvert.DeserializeObject<Claims>(userEntity.Claims);

            return _auth.GenerateTokenForUser(user);
        }
    }
}