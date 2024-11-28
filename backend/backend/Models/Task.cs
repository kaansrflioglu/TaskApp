using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class Task
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
           
    }
}
