using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApi.Data.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private readonly MyDbContext _db;

        public UsersRepo(MyDbContext db)
        {
            _db = db;
        }

        public UserEntity AddUser(UserEntity newUserEntity)
        {
            UserEntity user = _db.Users.Add(newUserEntity);

            _db.SaveChanges();

            return user;
        }

        public UserEntity GetByEmail(string email)
        {
            try
            {
                return _db.Users.FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
