using Microsoft.EntityFrameworkCore;
using PersonalInfo.Data;
using PersonalInfo.Models;

namespace PersonalInfo.SeedData
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
                        Relationship = ""
                    },
                    
                    new Person
                    {
                        FirstName = "Aleksandrs",
                        LastName = "Vilciņš",
                        BirthDate = DateTime.Parse("1991-2-22"),
                        PhoneNumber = "+371 26819488",
                        Address = "Hanzas street 118-2",
                        IsMerriged = true,
                        Relationship = ""
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
                        IsMerriged = true,
                        Relationship = ""
                    },
                    
                    new Person()
                    {
                        FirstName = "Gatis",
                        LastName = "Kodors",
                        BirthDate = DateTime.Parse("1993-3-19"),
                        PhoneNumber = "+371 26055136",
                        Address = "Junpils street 54-23",
                        IsMerriged = false,
                        Relationship = ""
                    },

                    new Person
                    {
                        FirstName = "Inese",
                        LastName = "Baltā",
                        BirthDate = DateTime.Parse("1992-3-14"),
                        PhoneNumber = "+371 26819488",
                        Address = "Gaujas street 118-2",
                        IsMerriged = true,
                        Relationship = ""
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
                    },
                    new Person()
                    {
                        FirstName = "Joe",
                        LastName = "Pink",
                        BirthDate = DateTime.Parse("1979-1-26"),
                        PhoneNumber = "+380 0977317184",
                        Address = "Bunina street 13-1",
                        IsMerriged = false,
                        Relationship = ""
                    },
                    new Person()
                    {
                        FirstName = "Antony",
                        LastName = "Rock",
                        BirthDate = DateTime.Parse("2001-2-28"),
                        PhoneNumber = "+371 28478021",
                        Address = "Kviešu street 13-1",
                        IsMerriged = true,
                        Relationship = "Alise Kodora"
                    },
                    new Person()
                    {
                        FirstName = "Ingūna",
                        LastName = "Kaupe",
                        BirthDate = DateTime.Parse("1989-2-12"),
                        PhoneNumber = "+371 28478021",
                        Address = "Briviabas street 13-1",
                        IsMerriged = false,
                        Relationship = ""
                    },
                    
                new Person()
                    {
                        FirstName = "Alise",
                        LastName = "Kodora",
                        BirthDate = DateTime.Parse("1989-2-12"),
                        PhoneNumber = "+371 28478021",
                        Address = "Ūlmaņa street 13-1",
                        IsMerriged = true,
                        Relationship = "Antony Rock"
                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}