using backend.Controllers;
using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DeleteTests
{
    private TaskContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase(databaseName: "TestTaskDb_DeleteTests")
            .Options;

        var context = new TaskContext(options);
        context.Tasks.Add(new backend.Models.Task
        {
            ID = 1,
            Title = "Task to Delete",
            Description = "Description",
            CreatedAt = DateTime.Now
        });
        context.SaveChanges();
        return context;
    }

    [Fact]
    public async Task DeleteTask_RemovesTask()
    {
        // Arrange
        var context = GetInMemoryDbContext();
        var controller = new TaskController(context);
        var taskId = 1;

        // Act
        var result = await controller.DeleteTask(taskId);

        // Assert
        Assert.IsType<NoContentResult>(result); 
        Assert.Null(context.Tasks.SingleOrDefault(t => t.ID == taskId));
    }


}
