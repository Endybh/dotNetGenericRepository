using System.Linq.Expressions;
using Lab.GenericRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace Lab.GenericRepository.Infrastructure
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        private readonly MedicalRecordContext _context;

        public Repository(MedicalRecordContext context)
        {
            _context = context;
        }
        public async Task<Entity> AddAsync(Entity entitie)
        {
            await _context.Set<Entity>().AddAsync(entitie);
            return entitie;
        }

        public Task DeleteAsync(Entity entitie)
        {
            _context.Remove(entitie);
            return Task.CompletedTask;
        }        

        public async Task<List<Entity>> SelectAsync(Expression<Func<Entity, bool>> predicate)
        {
            return await _context.Set<Entity>().Where(predicate).ToListAsync();
        }

        public Task<List<Entity>> SelectAsync(Expression<Func<Entity, bool>> predicate, params Expression<Func<Entity, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Entity entitie)
        {
            throw new NotImplementedException();
        }
    }
}
