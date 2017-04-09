using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotesApi.Auth;
using NotesApi.Data.Repositories;
using NotesApi.Models.Commands;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers.CommandsHandlers
{
    public class DeleteNotesCommandHandler : ICommandHandler<DeleteNotesCommand>
    {
        private readonly INotesRepo _notes;

        public DeleteNotesCommandHandler(INotesRepo notes)
        {
            _notes = notes;
        }

        public void Handle(DeleteNotesCommand command, IWebHydraContext context)
        {
            if (!context.User.HasClaim(c=>c.CanDeleteNote)) throw new AuthorizationException();

            _notes.DeleteNote(command.Id);
        }
    }
}
