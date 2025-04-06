// Define o namespace do projeto, organizando as classes em pastas lógicas
namespace TodoListAPI.Models
{
    // Define a classe que representa o modelo de dados para uma tarefa
    public class TaskItem
    {
        // Identificador único da tarefa (por exemplo, 1, 2, 3...)
        public int Id { get; set; }

        // Descrição da tarefa (ex: "Estudar MAUI")
        // A propriedade é inicializada como string vazia para evitar null
        public string Description { get; set; } = string.Empty;

        // Indica se a tarefa foi concluída ou não
        // Inicialmente definida como false (tarefa pendente)
        public bool IsCompleted { get; set; } = false;
    }
}
