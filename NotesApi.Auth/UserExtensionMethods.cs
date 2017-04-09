using System;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Auth
{
    public static class UserExtensionMethods
    {
        public static bool Exists(this User user)
        {
            if (user != null)
            {
                Guid result;
                return (Guid.TryParse(user.Id.ToString(), out result));
            }

            return false;
        }

        public static bool HasClaim(this User user, Func<Claims, bool> claims)
        {
            if (user.Exists())
            {
                if (claims(user.Claims)) return true;
            }

            return false;
        }
    }
}