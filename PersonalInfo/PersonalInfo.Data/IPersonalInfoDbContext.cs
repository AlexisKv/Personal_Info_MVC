using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonalInfo.Core.Models;

namespace PersonalInfo.Data
{
    public interface IPersonalInfoDbContext 
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Addresses> Addresses { get; set; }
        DbSet<Person> Person { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}