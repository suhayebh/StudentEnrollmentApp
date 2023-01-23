using FluentValidation;

namespace StudentEnrollment.API.DTOs.Authentication
{
    public class LoginDTO
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidator: AbstractValidator<LoginDTO> 
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
