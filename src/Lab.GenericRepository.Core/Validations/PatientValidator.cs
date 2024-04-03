using FluentValidation;

namespace Lab.GenericRepository.Core;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(p=>p.Name).NotEmpty().WithMessage("Name can not be empty");
        RuleFor(p=>p.BirthDate).Must(d=> d > DateTime.MinValue).WithMessage("Name can not be empty");
        RuleFor(p=>p.Address).NotEmpty().WithMessage("Address can not be empty");
        RuleFor(p=>p.NamePersonReference).NotEmpty().WithMessage("Must have a person to reference");
        RuleFor(p=>p.PhoneReference).NotEmpty().WithMessage("The phone of person reference must be filled");
    }
}
