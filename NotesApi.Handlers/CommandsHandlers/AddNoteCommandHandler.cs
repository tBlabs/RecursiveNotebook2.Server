using NotesApi.Data.Repositories;
using NotesApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApi.Data;
using WebHydra.Framework.Core;
using AutoMapper;
using NotesApi.Auth;
using WebHydra.Framework;

namespace NotesApi.Handlers
{
    public class AddNoteCommandHandler : ICommandHandler<AddNoteCommand>
    {
        private readonly INotesRepo _notes;

        public AddNoteCommandHandler(INotesRepo notesRepo)
        {
            _notes = notesRepo;
        }

        public void Handle(AddNoteCommand command, IWebHydraContext context)
        {
            if (!context.User.HasClaim(c => c.CanAddNote)) throw new AuthorizationException();

            Note note = Mapper.Map<Note>(command);
            note.UserId = context.User.Id;

            _notes.AddNote(note);
        }
    }
}
