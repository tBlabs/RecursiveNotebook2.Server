using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHydra.Framework.Core;

namespace NotesApi.Models.Commands
{
    public class DeleteNotesCommand : ICommand
    {
        public Guid Id;
    }
}
