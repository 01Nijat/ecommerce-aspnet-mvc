using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            
            var data= await _service.GetAllAsync();
            return View(data);
        }
        //Get Actor Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
           await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        // Get actors detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails=await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("empty");          
                return View(actorDetails);           
        }
    }
}
