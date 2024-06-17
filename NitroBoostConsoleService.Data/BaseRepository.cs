using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NitroBoostConsoleService.Shared.Interface.Repository;

namespace NitroBoostConsoleService.Data;

public abstract class BaseRepository<TType> : IBaseRepository<TType> where TType : class
{
    protected NitroboostConsoleContext _context;

    public BaseRepository(NitroboostConsoleContext context) => _context = context;

    public async Task<TType> Add(TType entity) => (await _context.Set<TType>().AddAsync(entity)).Entity;

    public async Task<IEnumerable<TType>> AddMany(IEnumerable<TType> entities)
    {
        List<TType> returnList = new List<TType>();
        foreach (TType entity in entities)
        {
            try { returnList.Add((await _context.Set<TType>().AddAsync(entity)).Entity); }
            catch {}
        }
        return returnList;
    }

    public void Delete(TType entity) => _context.Set<TType>().Remove(entity);

    public void DeleteMany(IEnumerable<TType> entities) => _context.Set<TType>().RemoveRange(entities);

    public async Task<IEnumerable<TType>> Find(Expression<Func<TType, bool>> predicate) =>
        await _context.Set<TType>().Where(predicate).ToListAsync();

    public async Task<IEnumerable<TType>> GetAll() => await _context.Set<TType>().ToListAsync();

    public void Update(TType entity) => _context.Set<TType>().Update(entity);

    public void UpdateMany(IEnumerable<TType> entities) => _context.Set<TType>().UpdateRange(entities);

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
}
