using System;

namespace NotesApi.Data
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ParentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Note: Id={Id}, UserId={UserId}, ParentId={ParentId}, Title={Title}, Content={Content}";
        }
    }
}