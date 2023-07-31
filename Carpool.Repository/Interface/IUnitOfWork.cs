namespace Carpool.Repository.Interface
{
    public interface IUnitOfWork
    {
        public Task<bool> SaveChanges();
    }
}
