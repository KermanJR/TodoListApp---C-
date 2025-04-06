using TodoListApp;
using Xunit;

namespace TodoListApp.Tests
{
    public class TaskManagerTests
    {
        [Fact]
        public void AddTask_ShouldAdd_ValidTask()
        {
            var manager = new TaskManager();

            manager.AddTask("Estudar MAUI");

            Assert.Single(manager.Tasks);
            Assert.Equal("Estudar MAUI", manager.Tasks[0]);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void AddTask_ShouldIgnore_InvalidTask(string input)
        {
            var manager = new TaskManager();

            manager.AddTask(input);

            Assert.Empty(manager.Tasks);
        }
    }
}
