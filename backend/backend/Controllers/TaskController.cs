using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskModel = backend.Models.Task;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _taskContext;

        public TaskController(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound("Task list is not available.");
            }
            return await _taskContext.Tasks.ToListAsync();
        }

        // GET: api/Task/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound("Task list is not available.");
            }

            var task = await _taskContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return task;
        }

        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel task)
        {
            if (_taskContext.Tasks == null)
            {
                return Problem("Task list is not initialized.");
            }

            _taskContext.Tasks.Add(task);
            await _taskContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.ID }, task);
        }

        // PUT: api/Task/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, TaskModel task)
        {
            if (id != task.ID)
            {
                return BadRequest("Task ID mismatch.");
            }

            _taskContext.Entry(task).State = EntityState.Modified;

            try
            {
                await _taskContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound($"Task with ID {id} not found.");
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Task/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound("Task list is not available.");
            }

            var task = await _taskContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _taskContext.Tasks.Remove(task);
            await _taskContext.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _taskContext.Tasks.Any(e => e.ID == id);
        }
    }
}
