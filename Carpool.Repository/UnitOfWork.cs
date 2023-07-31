using Carpool.Repository.Interface;
using CarPool.Data;

namespace Carpool.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext) { _dbContext = dbContext; }
        public async Task<bool> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
