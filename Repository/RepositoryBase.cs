using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Contracts;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        this.RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges
        ? this.RepositoryContext.Set<T>().AsNoTracking()
        : this.RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges
            ? this.RepositoryContext.Set<T>().Where(expression).AsNoTracking()
            : RepositoryContext.Set<T>().Where(expression);

    public void Create(T entity) => this.RepositoryContext.Set<T>().Add(entity);

    public void Update(T entity) => this.RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => this.RepositoryContext.Set<T>().Remove(entity);
}