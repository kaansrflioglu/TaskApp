using Microsoft.EntityFrameworkCore;
using ModelsTask = backend.Models.Task; 

namespace backend.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<ModelsTask> Tasks { get; set; } 
    }
}
