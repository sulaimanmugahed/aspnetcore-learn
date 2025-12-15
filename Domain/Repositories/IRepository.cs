using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;

namespace Domain;

public interface IRepository<T>
where T : Entity
{
    T? Get(int id);
    void Create(T entity);
    List<T> GetAll();
    List<T> GetAllWhere(Expression<Func<T, bool>> criteria);
    void Delete(int id);
    bool Exist(int id);

    Task<List<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task DeleteAsync(int id);
    Task CreateAsync(T entity);
}
