using System;
using WebHydra.Framework;
using WebHydra.Framework.Core;
using Xunit;

namespace NotesApi.Auth
{
    public class UserExtensionMethodsTest
    {
        [Fact]
        public void Test()
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Claims = new Claims();
            user.Claims.CanReadNote = true;
            user.Claims.CanAddNote = false;

            Assert.True(user.HasClaim(c=>c.CanReadNote));
            Assert.False(user.HasClaim(c=>c.CanAddNote));           
        }
    }
}
