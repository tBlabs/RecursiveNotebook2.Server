using WebHydra.Framework.Core;

namespace NotesApi.Models
{
    public class LoginQuery : IQuery<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}