using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppManageUsers.Data;
using WebAppManageUsers.Data.Entities;

namespace WebAppManageUsers.Controllers
{
    public class ClientsController : Controller
    {
        private readonly DataContext _context;
        public ClientsController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Clients != null ?
                        View(await _context.Clients.ToListAsync()):
                        Problem("Entity set 'DataContext.Countries'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            // Validamos que tanto el id que llega, como el de la tabla no sean nulo
            // si son nulos se retorna la vista NotFound
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            // Creamos una variable de tipo Cliente, que recibe el contexto de la base de datos
            Client client = await _context.Clients.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        public IActionResult Create()
        {
            return View();

        }

        // Definimos que el metodo utilizara Post, si no se define por defecto es Get
        [HttpPost]
        // Sobrecargamos el metodo Create
        public async Task<IActionResult> Create(Client client)
        {
            /*
             Validamos que el modelo si sea valido, como que valido, se valida que todos
            los Dataanotation se cumplan
             */
            if (ModelState.IsValid)
            {
                // Añadimos el client al contexto
                _context.Add(client);
                try
                {
                    // Intentamos guardar los cambion y mandamos la vista Index
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException dbUpdateException)
                {
                    // Validamos si ingresamos un valor dupicado a la base de datos
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un Cliente con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(client);
        }
    }
}
