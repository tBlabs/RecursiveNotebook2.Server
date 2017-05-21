using WebHydra.Framework.Core;

namespace WebHydra.Framework
{ 
    public interface IAuth
    {
        string GenerateTokenForUser(User user);
        User GetUserFromToken(string token);
    }
}