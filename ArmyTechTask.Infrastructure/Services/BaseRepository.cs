using System.Linq.Expressions;
using ArmyTechTask.Core.Common.Interfaces;
using ArmyTechTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Infrastructure.Services;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public T AddOne(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }
    public T Update(T entity)
    {
        _context.Update(entity);
        return entity;
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(string[]? includes)
    {
        var query = _context.Set<T>();
        if (includes is not null)
        {
            foreach (var include in includes)
                query.Include(include);
        }
        return await query.ToListAsync();
    }
    public IEnumerable<T> GetAll(string[]? includes = null)
    {
        var query = _context.Set<T>();
        if (includes is not null)
        {
            foreach (var include in includes)
                query.Include(include);
        }
        return query.ToList();
    }

    public T GetById(long Id)
    {
        return _context.Set<T>().Find(Id) ?? null!;
    }
    public T Find(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().SingleOrDefault(criteria)!;
    }

}