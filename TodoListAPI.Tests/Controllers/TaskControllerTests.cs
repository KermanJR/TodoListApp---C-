using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListAPI.Controllers;
using TodoListAPI.Data;
using TodoListAPI.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Tests
{
    public class TasksControllerTests
    {
        private TaskContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TaskContext>()
                .UseInMemoryDatabase(databaseName: "TestTasksDb")
                .Options;

            return new TaskContext(options);
        }

        [Fact]
      
        public async Task GetTasks_ReturnsAllTasks()
        {
            var options = new DbContextOptionsBuilder<TaskContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // novo banco isolado
                .Options;

            using var context = new TaskContext(options);
            context.Tasks.Add(new TaskItem { Description = "Tarefa 1" });
            context.Tasks.Add(new TaskItem { Description = "Tarefa 2" });
            context.SaveChanges();

            var controller = new TasksController(context);

            var result = await controller.GetTasks();

            var tasks = Assert.IsType<List<TaskItem>>(result.Value);
            Assert.Equal(2, tasks.Count); // ✅ agora deve passar
        }


        [Fact]
        public async Task PostTask_AddsTaskCorrectly()
        {
            var context = GetInMemoryContext();
            var controller = new TasksController(context);
            var newTask = new TaskItem { Description = "Nova tarefa" };

            var result = await controller.PostTask(newTask);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnTask = Assert.IsType<TaskItem>(createdResult.Value);
            Assert.Equal("Nova tarefa", returnTask.Description);
        }
    }
}
