using System;
using NotesApi.Data.Repositories;
using WebHydra.Framework.Core;
using NotesApi.Models;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using NotesApi.Data;
using AutoMapper;
using NotesApi.Auth;
using WebHydra.Framework;

namespace NotesApi.Handlers
{
    public class GetNotesQueryHandler : IQueryHandler<GetNotesQuery, NoteDto[]>
    {
        private readonly INotesRepo _notes;

        public GetNotesQueryHandler(INotesRepo notesRepo)
        {
            _notes = notesRepo;
        }

        public NoteDto[] Handle(GetNotesQuery query, IWebHydraContext context)
        {
            Console.WriteLine($"Fetching tab '{query.Id}'...");

            if (!context.User.HasClaim(c => c.CanReadNote)) throw new AuthorizationException();
          
            IEnumerable<Note> notes = _notes.GetNotes(query.Id, context.User.Id);

            IEnumerable<NoteDto> notesDtos = Mapper.Map<IEnumerable<Note>, IEnumerable<NoteDto>>(notes);
            
            return notesDtos.ToArray();
        }
    }
}