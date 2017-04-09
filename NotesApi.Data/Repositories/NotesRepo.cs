using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace NotesApi.Data.Repositories
{
    class NotesRepo : INotesRepo
    {
        private readonly MyDbContext _context;

        public NotesRepo(MyDbContext context)
        {
            _context = context;
        }

        public bool AddNote(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<Note> GetNotes(Guid parentId, Guid userId)
        {
            var list = _context.Notes.Where(n => n.ParentId == parentId && n.UserId == userId).ToList();

            return list;
        }

        public bool UpdateNote(Note note)
        {
            Note noteEntity = _context.Notes.SingleOrDefault(n => n.Id == note.Id);

            if (noteEntity == null) throw new Exception(note.Id + " not found");

            // Czy maper zrobi to samo czy nadpisze nule?????????          
            if (note.Title != null)
                noteEntity.Title = note.Title;
            if (note.Content != null)
                noteEntity.Content = note.Content;

            _context.Notes.AddOrUpdate(noteEntity);
            _context.SaveChanges();

            return true;
        }

        public Note GetSingleNote(Guid id)
        {
            return _context.Notes.FirstOrDefault(n => n.Id == id);
        }

        private readonly List<Guid> itemsToDelete = new List<Guid>(); // TODO: This should be Note's list

        private List<Guid> FindChildren(Guid parentId)
        {
            var rec = _context.Notes.Where(n => n.ParentId == parentId).Select(i => i.Id);
            //var rec = from x in _context.Notes
            //          where x.ParentId == parentId
            //          select x.Id;
            return rec.ToList();
        }

        private void FindAllChildren(Guid id)
        {
            itemsToDelete.Add(id);

            List<Guid> children = FindChildren(id);

            foreach (Guid c in children)
            {
                FindAllChildren(c);
            }
        }

        public bool DeleteNote(Guid id)
        {
            itemsToDelete.Clear();

            if (GetSingleNote(id) != null)
            {
                FindAllChildren(id);

                if (itemsToDelete.Count > 0)
                {
                    foreach (Guid i in itemsToDelete)
                    {
                        var noteToDelete = GetSingleNote(i);

                        if (noteToDelete != null)
                        {
                            _context.Notes.Remove(noteToDelete);
                        }
                    }

                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}