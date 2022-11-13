using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalInfo.Core.Models;
using PersonalInfo.Core.Services;

namespace PersonalInfo.Core;

public interface IPersonsService : IEntityService<Person>
{
    public Person[] GetPersons();
    public Task<List<Person>> SearchByLastName(string searchString);
    public Task<Person?> GetById(int? id);
    public bool IsDbEmpty();
    public List<string> AllFirstNames();
    public List<string> AllLastNames();
    public bool PersonExist(int id);
    public Task<Person?> FindAsyncPerson(int? id);
    public Person FindPersonByLastName(string lastName);
    public void StateModify(Person person);
    public Task<int> SaveAsync();
    public List<string> GetAllFullNames();
}