using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Models;
using Xunit;
using System.Threading.Tasks;

namespace TodoListAPI.Tests
{
    public class TaskContextTests
    {
        [Fact]
        public async Task CanInsertTaskIntoDatabase()
        {
            var options = new DbContextOptionsBuilder<TaskContext>()
                .UseInMemoryDatabase(databaseName: "InsertTaskTestDb")
                .Options;

            using (var context = new TaskContext(options))
            {
                var task = new TaskItem { Description = "Estudar para prova", IsCompleted = false };
                context.Tasks.Add(task);
                await context.SaveChangesAsync();
            }

            using (var context = new TaskContext(options))
            {
                var taskFromDb = await context.Tasks.FirstOrDefaultAsync();
                Assert.NotNull(taskFromDb);
                Assert.Equal("Estudar para prova", taskFromDb.Description);
                Assert.False(taskFromDb.IsCompleted);
            }
        }
    }
}
