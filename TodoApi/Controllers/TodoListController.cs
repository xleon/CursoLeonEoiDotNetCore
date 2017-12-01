using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoListController : Controller
    {
        private readonly TodoContext _context;

        public TodoListController(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Todas las listas
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetLists()
        {
            var lists = await _context.Lists
                .Include(x => x.Items) // indicamos explicitamente que se rellene el array de items de cada lista
                .ToListAsync();

            return Ok(lists);
        }

        /// <summary>
        /// Detalle de lista, incluyendo todas sus tareas
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todoList = await _context.Lists
                .Include(x => x.Items)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (todoList == null)
                return NotFound();

            return Ok(todoList);
        }

        /// <summary>
        /// Modificar/actualizar lista
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList([FromRoute] int id, [FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid || id != todoList.Id)
                return BadRequest(ModelState);

            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Lists.Any(e => e.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Crear lista (vacía)
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> PostTodoList([FromBody] TodoList todoList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Comprobar que el nombre de la lista es corecto
            if (string.IsNullOrEmpty(todoList.Name) || todoList.Name.Length < 3)
                return BadRequest(new { info = "El nombre de la lista debe contener al menos 3 caracteres"});

            // Comprobar que no existe una lista con el mismo nombre
            var exists = await _context.Lists.AnyAsync(x => x.Name == todoList.Name);
            if (exists)
                return BadRequest(new {info = "Ya existe una lista con este nombre"});

            _context.Lists.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.Id }, todoList);
        }

        /// <summary>
        /// Borrar lista.
        /// Por defecto se borrarán todas las tareas relacionadas
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todoList = await _context.Lists.SingleOrDefaultAsync(m => m.Id == id);
            if (todoList == null)
                return NotFound();

            _context.Lists.Remove(todoList);
            await _context.SaveChangesAsync();

            return Ok(todoList);
        }
    }
}