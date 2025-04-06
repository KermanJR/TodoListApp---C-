using System.Collections.ObjectModel;
using TodoListApp.Models;
using TodoListApp.Services;

namespace TodoListApp;

public partial class MainPage : ContentPage
{
    private TaskService _taskService = new();
    private ObservableCollection<TaskItem> _tasks = new();

    public MainPage()
    {
        InitializeComponent();
        TaskList.ItemsSource = _tasks;
        LoadTasks();
    }

    private async void LoadTasks()
    {
        _tasks = await _taskService.GetTasksAsync();
        TaskList.ItemsSource = _tasks;
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
        {
            var newTask = new TaskItem { Description = TaskEntry.Text };
            await _taskService.AddTaskAsync(newTask);
            TaskEntry.Text = string.Empty;
            LoadTasks();
        }
    }
}
