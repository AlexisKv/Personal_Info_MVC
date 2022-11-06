using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Models;

namespace PersonalInfo.Data
{
    public class PersonalInfoContext : DbContext
    {
        public PersonalInfoContext (DbContextOptions<PersonalInfoContext> options)
            : base(options)
        {
        }

        public DbSet<PersonalInfo.Models.Person> Person { get; set; } = default!;
    }
}
