using System.Collections.ObjectModel;

namespace TodoListApp
{
    public class TaskManager
    {
        public ObservableCollection<string> Tasks { get; } = new();

        public void AddTask(string task)
        {
            if (!string.IsNullOrWhiteSpace(task))
                Tasks.Add(task);
        }
    }
}
