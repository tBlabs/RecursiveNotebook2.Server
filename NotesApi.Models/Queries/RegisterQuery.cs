using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHydra.Framework.Core;

namespace NotesApi.Models.Queries
{
    public class RegisterQuery : IQuery<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
