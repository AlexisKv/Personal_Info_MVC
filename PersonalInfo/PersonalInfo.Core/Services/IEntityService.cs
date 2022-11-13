using System.Collections.Generic;
using System.Linq;
using PersonalInfo.Core.Models;

namespace PersonalInfo.Core.Services;

public interface IEntityService<T> where T: Entity
{
    public void Create(T entity);

    public void Delete(T entity);

    public void Update(T entity);

    public List<T> GetAll();

    public T GetById(int id);

    public IQueryable<T> Query();
}