// Importa o namespace do Entity Framework Core, que fornece os recursos de ORM (mapeamento objeto-relacional)
using Microsoft.EntityFrameworkCore;

// Importa o namespace onde está o modelo de dados TaskItem
using TodoListAPI.Models;

namespace TodoListAPI.Data
{
    // Define a classe TaskContext como um "contexto do banco de dados", herdando de DbContext
    public class TaskContext : DbContext
    {
        // Construtor da classe, recebe as opções de configuração do DbContext (como o provedor e a string de conexão)
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        // Cria uma propriedade que representa a tabela de tarefas no banco de dados
        // DbSet<TaskItem> indica que a tabela vai armazenar objetos do tipo TaskItem
        // O "=>" é uma expressão simplificada para retornar Set<TaskItem>(), que é a coleção rastreada pelo EF
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
