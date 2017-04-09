using System;
using WebHydra.Framework.Core;

namespace NotesApi.Models
{
    public class AddNoteCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Title { get; set; }
    }
}