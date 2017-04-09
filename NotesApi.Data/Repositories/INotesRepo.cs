using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApi.Data.Repositories
{
    public interface INotesRepo
    {
        IEnumerable<Note> GetNotes(Guid parentId, Guid userId);
        bool AddNote(Note note);
        bool DeleteNote(Guid id);
        bool UpdateNote(Note note);
    }
}
