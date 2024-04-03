using MediatR;

namespace Lab.GenericRepository.Core;

public class CreateCustomer : IRequest<Guid>
{
    public string Name{get;set;}
    public string ContactPhoneNumber{get;set;}
    public DateTime BirthDate{get;set;}
    public string Address{get;set;}
    public string NamePersonReference{get;set;}
    public string PhoneReference{get;set;}
}
