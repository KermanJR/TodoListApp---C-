// Importa o namespace onde está definida a classe TaskItem, que será testada
using TodoListAPI.Models;


// Importa a biblioteca xUnit, que fornece os atributos e métodos para testes
using Xunit;

namespace TodoListAPI.Tests.Models // Define o namespace do projeto de testes
{
    // Classe de teste para verificar o comportamento do modelo TaskItem
    public class TaskItemTests
    {
        // Define um teste unitário usando o atributo [Fact], que indica que o método abaixo é um teste que não recebe parâmetros
        [Fact]
        public void TaskItem_DefaultValues_ShouldBeCorrect()
        {
            // Cria uma nova instância da classe TaskItem, sem passar nenhum valor (usa os valores padrão)
            var task = new TaskItem();

            // Verifica se o valor padrão da propriedade Id é 0
            Assert.Equal(0, task.Id);

            // Verifica se o valor padrão da propriedade Description é uma string vazia
            Assert.Equal(string.Empty, task.Description);

            // Verifica se o valor padrão da propriedade IsCompleted é false
            Assert.False(task.IsCompleted);
        }
    }
}
