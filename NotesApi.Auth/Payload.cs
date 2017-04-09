using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHydra.Framework;

namespace NotesApi.Auth
{
    public class Payload
    {
        public Guid UserId { get; set; }
        public Claims UserClaims { get; set; }

        public Guid Random { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ExpirationTime { get; set; }

        public Payload()
        {
            Random = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }
    }
}
