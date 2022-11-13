using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalInfo.Core.Models;
using PersonalInfo.Data;
using PersonalInfo.Services;

namespace PersonalInfo.Controllers
{
    public class PersonsController : Controller
    {
        private readonly PersonsService _personsService;

        public PersonsController(PersonsService personsService)
        {
            _personsService = personsService;
        }
        
        public class TestRelationship
        {
            public int Id { get; set; }
            public string MerrigeName { get; set; }
        }

        public Array GetAllNames()
        {
            return _personsService.GetPersons();
        }
        
        public async Task<IActionResult> Index(string searchString)
        {
            return View( await _personsService.SearchByLastName(searchString));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _personsService.IsDbEmpty())
            {
                return NotFound();
            }

            Person person = await _personsService.GetById(id);
            
            if (person == null)
            {
                return NotFound();
            }
            

            return View(person);
        }

        public IActionResult Create()
        {
            var person = new Person();
            
            person.AllAddresses = new List<Addresses>();
            
            return View(person);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate," +
                             "PhoneNumber,Address,IsMerriged,Relationship, AllAddresses")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personsService.Create(person);

                await _personsService.SaveAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _personsService.IsDbEmpty())
            {
                return NotFound();
            }

            var person = await _personsService.GetById(id) ;
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,PhoneNumber,Address,IsMerriged,Relationship")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _personsService.Update(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        
        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _personsService.IsDbEmpty())
            {
                return NotFound();
            }

            var person = await _personsService.FindAsyncPerson(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        
        [HttpPost]
        public async Task<IActionResult> MerrigePopUp([FromForm]TestRelationship relationship)
        {

            var persone = await _personsService.FindAsyncPerson(relationship.Id);
            
            persone.Relationship = relationship.MerrigeName;
            
            var lastName = relationship.MerrigeName.Split(' ').Skip(1).FirstOrDefault();

            var secPerson = _personsService.FindPersonByLastName(lastName);
            
            var willBeAdded = persone.FirstName + " " + persone.LastName;

            if (secPerson != null)
            {
                secPerson.Relationship = willBeAdded;
                secPerson.IsMerriged = true;
            }

            _personsService.StateModify(persone);

            try
            {
                await _personsService.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(relationship.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_personsService.IsDbEmpty() == null)
            {
                return Problem("Entity set 'PersonalInfoContext.Person'  is null.");
            }
            Person person = await _personsService.GetById(id);
            if (person != null)
            {
                _personsService.Delete(person);
            }
            
            await _personsService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public ActionResult AddAddress()
        {
            var address = new Addresses();
            
            return PartialView("AllAddresses", address);
        }

        public async Task<List<string>> Qwe()
        {
           
            return await Task.FromResult(_personsService.GetAllFullNames());
        }

        private bool PersonExists(int id)
        {
          return _personsService.PersonExist(id);
        }
    
    }
}
