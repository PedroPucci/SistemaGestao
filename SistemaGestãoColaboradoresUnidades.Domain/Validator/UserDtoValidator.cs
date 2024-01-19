using FluentValidation;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestãoColaboradoresUnidades.Domain.Validator
{

    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x)
                .NotEmpty();

            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();

            RuleFor(x => x.Status)
                .NotEmpty().IsInEnum();
        }
    }
}