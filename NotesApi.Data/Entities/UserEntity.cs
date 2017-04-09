using System;

namespace NotesApi.Data
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Claims { get; set; } // as json 
    }
}