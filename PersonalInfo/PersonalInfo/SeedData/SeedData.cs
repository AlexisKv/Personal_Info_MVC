using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalInfo.Data;
using System;
using System.Linq;
using PersonalInfo.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonalInfoContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<PersonalInfoContext>>()))
            {
                // Look for any movies.
                if (context.Person.Any())
                {
                    return;   // DB has been seeded
                }

                context.Person.AddRange(
                    new Person()
                    {
                        FirstName = "Ilmārs",
                        LastName = "Ozols",
                        BirthDate = DateTime.Parse("1989-2-12"),
                        PhoneNumber = "+371 28478021",
                        Address = "Briviabas street 13-1",
                        IsMerriged = false,
                        Relationship = "Single"
                    },

                    new Person
                    {
                        FirstName = "Edgars",
                        LastName = "Saulīte",
                        BirthDate = DateTime.Parse("1999-1-12"),
                        PhoneNumber = "+371 28947655",
                        Address = "Alas street 44-1",
                        IsMerriged = true,
                        Relationship = "Olga Hļebs"
                    },

                    new Person
                    {
                        FirstName = "Alberts",
                        LastName = "Krivecs",
                        BirthDate = DateTime.Parse("1978-4-22"),
                        PhoneNumber = "+371 28472661",
                        Address = "Stirnu street 13-31",
                        IsMerriged = false,
                        Relationship = "Single"
                    },
                    
                    new Person()
                    {
                        FirstName = "Gatis",
                        LastName = "Kodors",
                        BirthDate = DateTime.Parse("1993-3-19"),
                        PhoneNumber = "+371 26055136",
                        Address = "Junpils street 54-23",
                        IsMerriged = false,
                        Relationship = "Single"
                    },

                    new Person
                    {
                        FirstName = "Olga",
                        LastName = "Hļebs",
                        BirthDate = DateTime.Parse("1989-2-14"),
                        PhoneNumber = "+371 28477201",
                        Address = "Spodrības street 138-2",
                        IsMerriged = true,
                        Relationship = "Edgars Saulīte"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}