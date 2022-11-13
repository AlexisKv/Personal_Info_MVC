using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core;
using PersonalInfo.Core.Models;
using PersonalInfo.Data;

namespace PersonalInfo.Services;

public class PersonsService : EntityService<Person>, IPersonsService
{
    public PersonsService(IPersonalInfoDbContext context) : base(context)
    {
    }

    public Person[] GetPersons()
    {
       return _context.Person.ToArray();
    }

    public Task<List<Person>> SearchByLastName(string searchString)
    {
        var person = from m in _context.Person
            select m;
        
        if (!String.IsNullOrEmpty(searchString))
        {
            person = person.Where(s => s.LastName!.Contains(searchString));
        }
        
        
        return person.ToListAsync();
        
    }

    public async Task<Person?> GetById(int? id)
    {
        return await _context.Person
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public bool IsDbEmpty()
    {
        return _context.Person == null;
    }

    public List<string> AllFirstNames()
    {
        return  _context.Person.Select(x => x.FirstName).ToList();
    }

    public List<string> AllLastNames()
    {
        return _context.Person.Select(x => x.LastName).ToList();
    }

    public bool PersonExist(int id)
    {
        return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
    }

    public async Task<Person?> FindAsyncPerson(int? id)
    {
        return await _context.Person.FindAsync(id);
    }

    public Person FindPersonByLastName(string lastName)
    {
        return _context.Person.FirstOrDefault(x => x.LastName == lastName);
    }

    public void StateModify(Person person)
    {
        _context.Entry(person).State = EntityState.Modified;
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public List<string> GetAllFullNames()
    {
        var space = " ";
        var allNames = AllFirstNames();
        var allSurnames = AllLastNames();
            
        var allFullNames = allNames.Zip(allSurnames, (n, s) => n + space + s);
        return allFullNames.ToList();
    }
}