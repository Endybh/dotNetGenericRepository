using System.Linq.Expressions;

namespace Lab.GenericRepository.Core
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        Task<Entity> AddAsync(Entity entitie);
        Task UpdateAsync(Entity entitie);
        Task<List<Entity>> SelectAsync(Expression<Func<Entity, bool>> predicate);
        Task<List<Entity>> SelectAsync(Expression<Func<Entity, bool>> predicate, params Expression<Func<Entity, object>>[] includes);        
        Task DeleteAsync(Entity entitie);
    }
}
