using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoListApp.Models;


namespace TodoListApp.Services
{
    public class TaskService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7230/api/tasks"; 

        public TaskService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<TaskItem>> GetTasksAsync()
        {
            var tasks = await _httpClient.GetFromJsonAsync<ObservableCollection<TaskItem>>(BaseUrl);
            return tasks ?? new ObservableCollection<TaskItem>();
        }

        public async Task AddTaskAsync(TaskItem task)
        {
            await _httpClient.PostAsJsonAsync(BaseUrl, task);
        }
    }
}
