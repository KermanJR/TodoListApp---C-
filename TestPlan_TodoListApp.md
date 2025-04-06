# 🧪 Plano de Testes - Aplicação TodoList (.NET MAUI + ASP.NET Core API)

## 📋 Visão Geral
Este documento define o plano de testes para a aplicação TodoList, composta por um front-end móvel em .NET MAUI e uma API back-end em ASP.NET Core. O objetivo é garantir a estabilidade e confiabilidade das funcionalidades principais da aplicação.

---

## ✅ Funcionalidades a Serem Testadas
- Criação de tarefas
- Listagem de tarefas
- Validação de dados ao criar tarefas
- Conexão com a API
- Persistência no banco de dados

---

## 🧪 Tipos de Testes

### Testes Unitários
- Testar se `TaskItem` possui valores padrão corretos.
- Testar se métodos de adição e recuperação funcionam isoladamente.

### Testes de Integração
- Validar comunicação entre controller e contexto de dados (`DbContext`).
- Verificar se a API retorna corretamente as tarefas do banco.

### Testes Funcionais (End-to-End Manual)
- Verificar se tarefas adicionadas pela aplicação aparecem corretamente na lista.
- Confirmar que tarefas inválidas (vazias) não são salvas.

---

## 🛠️ Ferramentas
- xUnit (testes unitários)
- Microsoft.EntityFrameworkCore.InMemory (testes de integração)
- GitHub Actions (automatização CI/CD)
- Visual Studio 2022

---

## 📁 Estrutura de Testes
```
TodoListAPI.Tests/
├── Models/
│   └── TaskItemTests.cs
├── Controllers/
│   └── TasksControllerTests.cs
```

---

## 🔄 Automatização CI/CD
- Os testes são executados automaticamente via GitHub Actions em cada `push` e `pull request`.
- O build falha se houver testes com falha.

---

## 🔍 Observações
- Testes devem cobrir pelo menos 80% do código crítico.
- Casos de borda devem ser considerados (ex: string vazia, nula, dados duplicados).

---

## 📅 Atualização
Este plano deve ser atualizado conforme a aplicação evolui com novas funcionalidades.