using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        // rozwiązanie tymczasowe
        private static Dictionary<int, ContactModel> _contacts = new();

        private static int _currentId;

        // Lista kontaktów
        public IActionResult Index()
        {
            return View(_contacts);
        }
    
        // Formularz dodania kontaktu
        public IActionResult Add()
        {
            return View();
        }

        // Odebranie danych z formularza i zapisanie w kontaktach
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Id = _currentId++;
            _contacts.Add(model.Id, model);
            return View("Index", _contacts);
        }

        public IActionResult Delete(int id)
        {
            _contacts.Remove(id);
            return View("Index", _contacts);
        }

        public IActionResult Details(int id)
        {
            return View(_contacts[id]);
        }
    
        public IActionResult Edit(int id)
        {
            if (_contacts.TryGetValue(id, out var contact))
            {
                return View(contact);
            }
            return NotFound();
        }

        // POST: Zapisz zmiany kontaktu
        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
        
            if (_contacts.ContainsKey(model.Id))
            {
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
            }
        
            return NotFound();
        }
    }
}