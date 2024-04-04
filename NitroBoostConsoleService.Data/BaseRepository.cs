using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NitroBoostConsoleService.Dependency.Interface.Repository;

namespace NitroBoostConsoleService.Data
{
    public abstract class BaseRepository<TType> : IBaseRepository<TType>
    {
        private Context _context;

        public BaseRepository(Context context) => _context = context;

        public Task<TType> Add(TType newObject)
        {
            throw new NotImplementedException();
        }

        public Task<TType> AddMany(IEnumerable<TType> newObjects)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int objectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TType>> Find(Expression<Func<TType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TType> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public TType Update(TType updatedObject)
        {
            throw new NotImplementedException();
        }

        public TType UpdateMany(IEnumerable<TType> updatedObjects)
        {
            throw new NotImplementedException();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();
        }
    }
}
