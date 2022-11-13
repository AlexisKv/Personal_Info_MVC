// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using PersonalInfo.Data;
// using PersonalInfo.Models;
//
// namespace PersonalInfo.Controllers
// {
//     public class PersonsController : Controller
//     {
//         private readonly PersonalInfoContext _context;
//
//         public PersonsController(PersonalInfoContext context)
//         {
//             _context = context;
//         }
//         
//         public class TestRelationship
//         {
//             public int Id { get; set; }
//             public string MerrigeName { get; set; }
//         }
//
//         public Array GetAllNames()
//         {
//             
//             return _context.Person.ToArray();
//         }
//         
//         // GET: Persons
//         public async Task<IActionResult> Index(string searchString)
//         {
//             var person = from m in _context.Person
//                 select m;
//
//             if (!String.IsNullOrEmpty(searchString))
//             {
//                 person = person.Where(s => s.LastName!.Contains(searchString));
//             }
//
//             return View(await person.ToListAsync());
//         }
//         
//
//         // GET: Persons/Details/5
//         public async Task<IActionResult> Details(int? id)
//         {
//             if (id == null || _context.Person == null)
//             {
//                 return NotFound();
//             }
//
//             var person = await _context.Person
//                 .FirstOrDefaultAsync(m => m.Id == id);
//             if (person == null)
//             {
//                 return NotFound();
//             }
//
//             return View(person);
//         }
//
//         // GET: Persons/Create
//         public IActionResult Create()
//         {
//             var person = new Person();
//             person.AllAddresses = new List<Addresses>();
//             
//             return View(person);
//         }
//
//         // POST: Persons/Create
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate," +
//                              "PhoneNumber,Address,IsMerriged,Relationship, AllAddresses")] Person person)
//         {
//             if (ModelState.IsValid)
//             {
//                _context.Add(person);
//                 //
//                 // var newAddress = person.AllAddresses.Where(s => !s.IsDeleted && s.Id == 0);
//                 //
//                 // var updated = person.AllAddresses.Where(s => !s.IsDeleted && s.Id != 0);
//                 //
//                 // var deleteAddress = person.AllAddresses.Where(s => s.IsDeleted && s.Id != 0);
//                 
//                // _context.Remove(deleteAddress);
//                // _context.Add(newAddress);
//                _context.Add(person);
//                 
//                 await _context.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(person);
//         }
//
//         // GET: Persons/Edit/5
//         public async Task<IActionResult> Edit(int? id)
//         {
//             if (id == null || _context.Person == null)
//             {
//                 return NotFound();
//             }
//
//             var person = await _context.Person.FindAsync(id);
//             if (person == null)
//             {
//                 return NotFound();
//             }
//             return View(person);
//         }
//         
//         // POST: Persons/Edit/5
//         // To protect from overposting attacks, enable the specific properties you want to bind to.
//         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate,PhoneNumber,Address,IsMerriged,Relationship")] Person person)
//         {
//             if (id != person.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//                 try
//                 {
//                     _context.Update(person);
//                     await _context.SaveChangesAsync();
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {
//                     if (!PersonExists(person.Id))
//                     {
//                         return NotFound();
//                     }
//                     else
//                     {
//                         throw;
//                     }
//                 }
//                 return RedirectToAction(nameof(Index));
//             }
//             return View(person);
//         }
//         
//         
//
//         // GET: Persons/Delete/5
//         public async Task<IActionResult> Delete(int? id)
//         {
//             if (id == null || _context.Person == null)
//             {
//                 return NotFound();
//             }
//
//             var person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);
//             if (person == null)
//             {
//                 return NotFound();
//             }
//
//             return View(person);
//         }
//         
//         [HttpPost]
//         public async Task<IActionResult> MerrigePopUp([FromForm]TestRelationship relationship)
//         {
//             
//             var persone = await _context.Person.FindAsync(relationship.Id);
//             
//             persone.Relationship = relationship.MerrigeName;
//             
//             var lastName = relationship.MerrigeName.Split(' ').Skip(1).FirstOrDefault();
//
//             var secPerson = _context.Person.FirstOrDefault(x => x.LastName == lastName);
//             
//             var willBeAdded = persone.FirstName + " " + persone.LastName;
//
//             if (secPerson != null)
//             {
//                 secPerson.Relationship = willBeAdded;
//                 secPerson.IsMerriged = true;
//             }
//             
//             _context.Entry(persone).State = EntityState.Modified;
//
//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!PersonExists(relationship.Id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return RedirectToAction("Index");
//         }
//       
//         // POST: Persons/Delete/5
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(int id)
//         {
//             if (_context.Person == null)
//             {
//                 return Problem("Entity set 'PersonalInfoContext.Person'  is null.");
//             }
//             var person = await _context.Person.FindAsync(id);
//             if (person != null)
//             {
//                 _context.Person.Remove(person);
//             }
//             
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//         
//         public ActionResult AddAddress()
//         {
//             var address = new Addresses();
//             
//             return PartialView("AllAddresses", address);
//         }
//
//         public async Task<List<string>> Qwe()
//         {
//             var space = " ";
//             var allNames = _context.Person.Select(x => x.FirstName).ToList();
//             var allSurnames = _context.Person.Select(x => x.LastName).ToList();
//             
//             var allFullNames = allNames.Zip(allSurnames, (n, s) => n + space + s);
//             return await Task.FromResult(allFullNames.ToList());
//         }
//
//         private bool PersonExists(int id)
//         {
//           return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
//         }
//     
//     }
// }
