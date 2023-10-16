using PaintyTestTask.Entities;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<T> Add(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Delete(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteById(int Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistId(int Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(int Skip, int Count, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int Id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IPage<T>> GetPage(int PageIndex, int PageSize, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
