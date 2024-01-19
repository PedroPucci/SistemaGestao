using FluentValidation;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestãoColaboradoresUnidades.Domain.Validator
{
    public class UnityDtoValidator : AbstractValidator<UnityDto>
    {
        public UnityDtoValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Code)
                .NotEmpty();
        }
    }
}
