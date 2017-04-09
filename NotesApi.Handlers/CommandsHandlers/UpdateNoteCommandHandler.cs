using System;
using AutoMapper;
using NotesApi.Auth;
using NotesApi.Data;
using NotesApi.Data.Repositories;
using NotesApi.Models;
using WebHydra.Framework;
using WebHydra.Framework.Core;

namespace NotesApi.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand>
    {
        private readonly INotesRepo _notes;

        public UpdateNoteCommandHandler(INotesRepo notesRepo)
        {
            _notes = notesRepo;
        }

        public void Handle(UpdateNoteCommand command, IWebHydraContext context)
        {
            if (!context.User.HasClaim(c => c.CanChangeNote)) throw new AuthorizationException();

            if (command.tab == null) throw new Exception("empty tab");
       
            Note note = Mapper.Map<NoteDto, Note>(command.tab);

            if (note == null) throw new Exception("mapping problem");
            
            _notes.UpdateNote(note);          
        }
    }
}