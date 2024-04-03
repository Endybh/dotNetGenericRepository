using MediatR;

namespace Lab.GenericRepository.Core;

public class CreatePatientHandler : IRequestHandler<CreateCustomer, Guid>
{
    private readonly NotificationContext _notificationContext;
    private readonly IPatientService _patientService;

    public CreatePatientHandler(NotificationContext notificationContext, IPatientService patientService)
    {
        _notificationContext = notificationContext;
        _patientService = patientService;
    }
    public async Task<Guid> Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        var patient = new Patient(request.Name, request.ContactPhoneNumber, request.BirthDate, 
                                  request.Address, request.NamePersonReference, request.PhoneReference);
        if(patient.Invalid)
        {
            _notificationContext.AddNotifications(patient.ValidationResult);
            return Guid.Empty;
        }

        await _patientService.Include(patient);

        return patient.Id;
    }
}
