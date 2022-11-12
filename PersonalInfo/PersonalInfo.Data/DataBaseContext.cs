using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Models;

namespace PersonalInfo.Data;

public class DataBaseContext: DbContext, IPersonalInfoDbContext
{
    public DataBaseContext(DbContextOptions options) : base(options)
    {
            
    }
    
    public DbSet<Addresses> Addresses { get; set; }
    public DbSet<Person> Person { get; set; }
    
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}