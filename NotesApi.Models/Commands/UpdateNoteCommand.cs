using System;
using WebHydra.Framework.Core;

namespace NotesApi.Models
{
    public class UpdateNoteCommand : ICommand
    {
        public NoteDto tab; // Note is a Tab on client side! Do not change that name!
    }
}