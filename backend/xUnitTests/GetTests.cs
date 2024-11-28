using backend.Controllers;
using backend.Data;
using Microsoft.EntityFrameworkCore;

public class GetTests
{
    private TaskContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase(databaseName: $"TestTaskDb_{Guid.NewGuid()}")
            .Options;

        var context = new TaskContext(options);
        context.Tasks.AddRange(new List<backend.Models.Task>
    {
        new backend.Models.Task { ID = 1, Title = "Task 1", Description = "Description 1", CreatedAt = DateTime.Now },
        new backend.Models.Task { ID = 2, Title = "Task 2", Description = "Description 2", CreatedAt = DateTime.Now }
    });
        context.SaveChanges();
        return context;
    }


    [Fact]
    public async System.Threading.Tasks.Task GetTasks_ReturnsAllTasks()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TaskController(context);

        // Act
        var result = await controller.GetTasks();

        // Assert
        Assert.NotNull(result);
        var tasks = Assert.IsType<List<backend.Models.Task>>(result.Value);
        Assert.Equal(2, tasks.Count);

    }

    [Fact]
    public async System.Threading.Tasks.Task GetTask_ReturnsTaskById()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TaskController(context);
        var taskId = 2;

        // Act
        var result = await controller.GetTask(taskId);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Value);
        var task = Assert.IsType<backend.Models.Task>(result.Value);
        Assert.Equal(taskId, task.ID);

    }
}
