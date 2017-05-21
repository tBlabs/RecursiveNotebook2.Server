using System;
using WebHydra.Framework.Utils;

namespace NotesApi.Models
{
    public class NoteDto // equivalent of Tab in frontend model
    {
        public Guid id { get; set; } // JavaScript JSON parser REQUIRES small letter!
        public Guid parentId { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public override string ToString()
        {
            return Dump.Props(this);
        }
    }
}