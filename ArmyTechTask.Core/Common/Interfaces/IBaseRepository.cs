using System.Linq.Expressions;
namespace ArmyTechTask.Core.Common.Interfaces;

public interface IBaseRepository<T> where T : class
{
    T GetById(long Id);
    Task<IEnumerable<T>> GetAllAsync(string[]? includes = null);
    IEnumerable<T> GetAll(string[]? includes = null);
    T Find(Expression<Func<T, bool>> criteria);
    T AddOne(T entity);
    T Update(T entity);
    void Delete(T entity);
}