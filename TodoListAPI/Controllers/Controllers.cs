// Importa recursos para criar controllers e ações HTTP
using Microsoft.AspNetCore.Mvc;
// Importa recursos para trabalhar com operações assíncronas em banco de dados
using Microsoft.EntityFrameworkCore;
// Importa o contexto de banco de dados da aplicação
using TodoListAPI.Data;
// Importa o modelo de dados TaskItem
using TodoListAPI.Models;

namespace TodoListAPI.Controllers
{
    // Indica que esta classe é uma API Controller, ou seja, usada para responder requisições HTTP (ex: GET, POST)
    [ApiController]

    // Define a rota base da API. O [controller] será substituído automaticamente por "tasks"
    // Ou seja, a URL base será: api/tasks
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        // Injeção de dependência do contexto do banco de dados
        private readonly TaskContext _context;

        // Construtor que recebe o contexto e armazena em uma variável privada
        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // Define um endpoint HTTP GET: api/tasks
        // Retorna a lista de tarefas do banco de dados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            // Consulta assíncrona à tabela de tarefas e retorna como lista
            return await _context.Tasks.ToListAsync();
        }

        // Define um endpoint HTTP POST: api/tasks
        // Cria uma nova tarefa no banco
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTask(TaskItem task)
        {
            // Adiciona a nova tarefa ao contexto
            _context.Tasks.Add(task);

            // Salva as alterações no banco de forma assíncrona
            await _context.SaveChangesAsync();

            // Retorna o status 201 (Created) com os dados da nova tarefa criada
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }
    }
}
