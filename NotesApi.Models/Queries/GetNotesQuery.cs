using System;
using WebHydra.Framework.Core;

namespace NotesApi.Models
{
    public class GetNotesQuery : IQuery<NoteDto[]>
    {
        public Guid Id { get; set; }
    }
}