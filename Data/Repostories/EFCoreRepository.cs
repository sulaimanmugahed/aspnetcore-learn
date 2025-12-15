using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;


namespace Data;


public class EFCoreRepository<T>(AppDbContext context) : IRepository<T>
where T : Entity
{
    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public async Task CreateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();

    }

    public void Delete(int id)
    {
        var entity = context.Set<T>().Find(id);
        if (entity is not null)
        {

            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity is not null)
        {

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

        }
    }

    public bool Exist(int id)
    {
        var existEntity = context.Set<T>().Find(id);

        if (existEntity is not null)
        {
            return true;
        }
        return false;
    }

    public T? Get(int id)
    {
        return context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public List<T> GetAllWhere(Expression<Func<T, bool>> criteria)
    {
        return context.Set<T>().Where(criteria).ToList();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }
}
