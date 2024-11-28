using backend.Controllers;
using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PostTests
{
    private TaskContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase(databaseName: "TestTaskDb_PostTests")
            .Options;

        var context = new TaskContext(options);
        context.SaveChanges();
        return context;
    }

    [Fact]
    public async System.Threading.Tasks.Task PostTask_AddsNewTask()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TaskController(context);
        var newTask = new backend.Models.Task
        {
            Title = "New Task",
            Description = "New Task Description",
            CreatedAt = DateTime.Now
        };

        // Act
        var result = await controller.PostTask(newTask);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreatedAtActionResult>(result.Result); 

        var createdTask = context.Tasks.SingleOrDefault(t => t.Title == "New Task");
        Assert.NotNull(createdTask);
        Assert.Equal("New Task", createdTask.Title);
        Assert.Equal("New Task Description", createdTask.Description);

    }
}
