namespace Lab.GenericRepository.Core;

public class BaseEntity
{
    public Guid Id{get;set;}
    public DateTime CreatedOn{get;set;}
    public DateTime DeletedOn{get;set;}
    public DateTime UpdatedOn{get;set;}
}
