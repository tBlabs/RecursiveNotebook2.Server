using FluentValidation;

namespace NotesApi.Models
{
    public class NoteDtoValidator : AbstractValidator<NoteDto>
    {
        public NoteDtoValidator()
        {
            RuleFor(note => note.title).Length(1,50);
        }
    }
}