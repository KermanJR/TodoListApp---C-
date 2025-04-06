// Importa suporte ao Entity Framework com funcionalidades de acesso a banco de dados
using Microsoft.EntityFrameworkCore;

// Importa o namespace onde está o contexto do banco de dados (classe TaskContext)
using TodoListAPI.Data;


// Cria o construtor da aplicação web, com suporte a configuração e serviços
var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados ao contêiner de injeção de dependência
// Usa SQLite como banco, cria e define o banco de dados como "tasks.db"
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// Adiciona o suporte a controladores (controllers) MVC (Busca os controladores)
builder.Services.AddControllers();

// Adiciona suporte para descoberta de endpoints da API (Busca os Endpoints)
builder.Services.AddEndpointsApiExplorer();

// Adiciona o Swagger para documentação e teste da API (Adiciona a documentação Swagger)
builder.Services.AddSwaggerGen();


// Constrói a aplicação baseada na configuração feita acima
var app = builder.Build();


// Garante que o banco de dados será criado, caso ainda não exista
// Cria um escopo temporário de serviço para acessar o contexto do banco
using (var scope = app.Services.CreateScope())
{
    // Obtém uma instância do contexto do banco
    var db = scope.ServiceProvider.GetRequiredService<TaskContext>();

    // Garante que o banco de dados (e suas tabelas) seja criado
    db.Database.EnsureCreated();
}


// Ativa o middleware do Swagger para documentação da API
app.UseSwagger();
app.UseSwaggerUI();

// Redireciona requisições HTTP para HTTPS
//app.UseHttpsRedirection();


// Ativa a autorização (sem autenticação configurada por enquanto)
app.UseAuthorization();

// Mapeia os controladores para as rotas HTTP
app.MapControllers();

// Inicia a aplicação web
app.Run();
