using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
     private readonly TodoContext _context;

        public TasksController(TodoContext context)
        {
            _context = context;
        }
    private static List<TodoTask> tasks = new List<TodoTask>();
    private static int nextId = 1;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
    {
        var tasks = await _context.TodoTasks.ToListAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TodoTask>> CreateTask(TodoTask task)
    {
        _context.TodoTasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchTask(int id, [FromBody] UpdateTodoTask updatedTask)
    {
        var task = await _context.TodoTasks.FindAsync(id);
        if (task == null) return NotFound();

        if (!string.IsNullOrWhiteSpace(updatedTask.Title))
        {
            task.Title = updatedTask.Title;
        }

        if (!string.IsNullOrWhiteSpace(updatedTask.Description))
        {
            task.Description = updatedTask.Description;
        }

        if (!string.IsNullOrWhiteSpace(updatedTask.Status))
        {
            task.Status = updatedTask.Status;
        }

        if (!string.IsNullOrWhiteSpace(updatedTask.Type))
        {
            task.Type = updatedTask.Type;
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.TodoTasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.TodoTasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
