using backend.Controllers;
using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PutTests
{
    private TaskContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase(databaseName: "TestTaskDb_PutTests")
            .Options;

        var context = new TaskContext(options);
        context.Tasks.Add(new backend.Models.Task
        {
            ID = 1,
            Title = "Old Task",
            Description = "Old Description",
            CreatedAt = DateTime.Now
        });
        context.SaveChanges();
        return context;
    }

    [Fact]
    public async Task PutTask_UpdatesExistingTask()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TaskController(context);
        var updatedTask = new backend.Models.Task
        {
            ID = 1,
            Title = "Updated Task",
            Description = "Updated Description",
            CreatedAt = DateTime.Now
        };

        var existingTask = context.Tasks.SingleOrDefault(t => t.ID == 1);
        if (existingTask != null)
        {
            context.Entry(existingTask).State = EntityState.Detached;
        }

        // Act
        var result = await controller.PutTask(1, updatedTask);

        // Assert
        Assert.IsType<NoContentResult>(result); 
    }



}
