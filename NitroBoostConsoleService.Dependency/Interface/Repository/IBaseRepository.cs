using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NitroBoostConsoleService.Dependency.Interface.Repository
{
    public interface IBaseRepository<TType> : IAsyncDisposable
    {
        Task<TType> Get(int id);
        Task<IEnumerable<TType>> Find(Expression<Func<TType, bool>> predicate);
        Task<IEnumerable<TType>> GetAll();
        Task<TType> Add(TType newObject);
        Task<TType> AddMany(IEnumerable<TType> newObjects);
        TType Update(TType updatedObject);
        TType UpdateMany(IEnumerable<TType> updatedObjects);
        bool Delete(int objectId);
    }
}
