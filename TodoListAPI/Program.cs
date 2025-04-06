// Importa suporte ao Entity Framework com funcionalidades de acesso a banco de dados
using Microsoft.EntityFrameworkCore;

// Importa o namespace onde est� o contexto do banco de dados (classe TaskContext)
using TodoListAPI.Data;


// Cria o construtor da aplica��o web, com suporte a configura��o e servi�os
var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados ao cont�iner de inje��o de depend�ncia
// Usa SQLite como banco, cria e define o banco de dados como "tasks.db"
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// Adiciona o suporte a controladores (controllers) MVC (Busca os controladores)
builder.Services.AddControllers();

// Adiciona suporte para descoberta de endpoints da API (Busca os Endpoints)
builder.Services.AddEndpointsApiExplorer();

// Adiciona o Swagger para documenta��o e teste da API (Adiciona a documenta��o Swagger)
builder.Services.AddSwaggerGen();


// Constr�i a aplica��o baseada na configura��o feita acima
var app = builder.Build();


// Garante que o banco de dados ser� criado, caso ainda n�o exista
// Cria um escopo tempor�rio de servi�o para acessar o contexto do banco
using (var scope = app.Services.CreateScope())
{
    // Obt�m uma inst�ncia do contexto do banco
    var db = scope.ServiceProvider.GetRequiredService<TaskContext>();

    // Garante que o banco de dados (e suas tabelas) seja criado
    db.Database.EnsureCreated();
}


// Ativa o middleware do Swagger para documenta��o da API
app.UseSwagger();
app.UseSwaggerUI();

// Redireciona requisi��es HTTP para HTTPS
//app.UseHttpsRedirection();


// Ativa a autoriza��o (sem autentica��o configurada por enquanto)
app.UseAuthorization();

// Mapeia os controladores para as rotas HTTP
app.MapControllers();

// Inicia a aplica��o web
app.Run();
