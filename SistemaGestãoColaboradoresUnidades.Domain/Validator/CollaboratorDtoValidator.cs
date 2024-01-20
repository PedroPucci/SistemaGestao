using FluentValidation;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestãoColaboradoresUnidades.Domain.Validator
{
    public class CollaboratorDtoValidator : AbstractValidator<CollaboratorDto>
    {
        public CollaboratorDtoValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}