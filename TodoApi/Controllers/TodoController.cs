using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Todas las tareas, sin filtrar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
            => Ok(await _context.Items.ToListAsync());

        /// <summary>
        /// Tareas filtradas por id de lista
        /// </summary>
        [HttpGet("bylist/{listId:int}")]
        public async Task<IActionResult> GetByList([FromRoute]int listId)
        {
            // Comprobar que los parámetros de entrada son correctos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Comprobar que la lista con id 'listId' existe
            var list = await _context.Lists.FirstOrDefaultAsync(x => x.Id == listId);
            if (list == null)
                return NotFound(new {info = "No existe ninguna lista con la id proporcionada"});

            // Devolver la lista
            var items = await _context.Items
                .Where(x => x.TodoListId == listId)
                .ToListAsync();

            return Ok(items);
        }

        /// <summary>
        /// Detalle de tarea por id
        /// </summary>
        [HttpGet("{id:int}", Name = "GetTodoItem")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.Items
                .SingleOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetTodoItem", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.Items
                .SingleOrDefaultAsync(x => x.Id == id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] TodoItem item)
        {
            if(!ModelState.IsValid || id != item.Id)
                return BadRequest(ModelState);

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Items.Any(x => x.Id == id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
    }
}
