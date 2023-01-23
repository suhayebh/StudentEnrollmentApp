using FluentValidation;

namespace StudentEnrollment.API.DTOs.Authentication
{
    public class RegisterDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            Include(new LoginDTOValidator());

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("You must've have a first name, right?.. right?");
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty()
                .Must((dob) => { 
                    if(dob.HasValue)
                        return dob.Value < DateTime.Now.AddYears(-15);
                    return true;                
                })
                .WithMessage("You must be at least 15 years old.");
        }
    }
}
