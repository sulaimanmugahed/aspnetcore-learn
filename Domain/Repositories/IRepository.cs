using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Domain;

public interface IRepository<T>
where T : class
{
    T? Get(int id);
    void Create(T entity);
    List<T> GetAll();
    void Delete(int id);

    Task<List<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task DeleteAsync(int id);
    Task CreateAsync(T entity);
}
