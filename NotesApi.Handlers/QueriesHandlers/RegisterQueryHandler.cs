using System;
using Newtonsoft.Json;
using NotesApi.Auth;
using NotesApi.Data;
using NotesApi.Data.Repositories;
using WebHydra.Framework.Core;
using NotesApi.Models.Queries;
using WebHydra.Framework;

namespace NotesApi.Handlers
{
    public class RegisterQueryHandler : IQueryHandler<RegisterQuery, string>
    {
        private readonly IAuth _auth;
        private readonly IUsersRepo _users;

        public RegisterQueryHandler(IAuth auth, IUsersRepo users)
        {
            _auth = auth;
            _users = users;
        }

        public string Handle(RegisterQuery query, IWebHydraContext context)
        {
            Console.WriteLine($"Registering with '{query.Email}' and '{query.Password}'...");

            // TODO validation

            UserEntity user = _users.GetByEmail(query.Email);
            if (user != null)
            {
                throw new UserAlreadyExistsException();
            }

            UserEntity userEntity = new UserEntity()
            {
                Claims = JsonConvert.SerializeObject(new Claims()),
                Id = new Guid(),
                Email = query.Email,
                Password = query.Password
            };

            _users.AddUser(userEntity);

            User user2 = new User();
            user2.Id = userEntity.Id;
            user2.Claims = JsonConvert.DeserializeObject<Claims>(userEntity.Claims);

            return _auth.GenerateTokenForUser(user2);                 
        }
    }
}