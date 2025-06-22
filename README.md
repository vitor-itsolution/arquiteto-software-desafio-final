# 🧱 Projeto com Arquitetura MVC - .NET 8

## 📚 Objetivos de Ensino

Este projeto visa exercitar os seguintes conceitos:
- Fundamentos de Arquitetura de Software.
- Requisitos Arquiteturais e Modelagem Arquitetural.
- Design Patterns, Estilos e Padrões Arquiteturais.
- Principais Arquiteturas de Software da Atualidade.

---

## 🚀 Tecnologia Utilizada

- **Linguagem**: C# (.NET 8)
- **Framework**: ASP.NET Core Web API
- **Padrão Arquitetural**: MVC (Model-View-Controller)
- **Banco de Dados**: SQL Server (ou InMemory para testes)
- **ORM**: Entity Framework Core
- **Ferramentas**: Swagger

---

## 🔧 Funcionalidades da API

- CRUD completo de `Cliente`
- Contagem de registros
- Busca por nome e por ID

### Endpoints Disponíveis

| Método HTTP | URI                        | Descrição                        |
|-------------|----------------------------|----------------------------------|
| GET         | /api/customers             | Lista todos os clientes          |
| GET         | /api/customers/{id}        | Retorna cliente por ID           |
| GET         | /api/customers/name/{name} | Retorna clientes por nome        |
| GET         | /api/customers/count       | Retorna total de registros       |
| POST        | /api/customers             | Cria um novo cliente             |
| PUT         | /api/customers/{id}        | Atualiza um cliente              |
| DELETE      | /api/customers/{id}        | Deleta um cliente                |

---

## 🗂️ Estrutura de Pastas do Projeto (.NET)

```plaintext
src/
└── ApiClientes/
    ├── Controllers/         # Controladores REST
    │   └── CustomersController.cs
    ├── Models/              # Entidades de domínio
    │   └── Customer.cs
    ├── Services/            # Regras de negócio
    │   └── CustomerService.cs
    │   └── ICustomerService.cs
    ├── Repositories/        # Interface e implementação de persistência
    │   └── ICustomerRepository.cs
    │   └── CustomerRepository.cs
    ├── Data/                # DbContext
    │   └── Context/AppDbContext.cs    
    ├── Data/                # Configurações das tabelas do banco de dados
    │   └── Mappings
    └── Program.cs           # Configuração principal
```

---

## 🧠 Explicação dos Componentes (MVC)

| Camada         | Descrição                                                                       |
| -------------- | ------------------------------------------------------------------------------- |
| **Model**      | Define a entidade `Customer` com propriedades como `Id`, `Name`, `Email`.       |
| **Controller** | Expõe os endpoints HTTP e chama os serviços.                                    |
| **Service**    | Implementa a lógica de negócio, validações e orquestra chamadas ao repositório. |
| **Repository** | Interface com o banco de dados usando EF Core.                                  |
| **Data**       | Classe `DbContext` do EF Core que define o mapeamento e banco de dados.         |


---

## 🧩 Diagrama Arquitetural - C4 Model

### 🔹 Nível 1 — Contexto

```plaintext
[Parceiros Externos]
        │
        ▼
[API Pública de Clientes (.NET 8)]
        │
        ▼
[Camada de Serviço]
        │
        ▼
[SQL Server]
```

### 🔹 Nível 2 — Container

- API REST em .NET 8
- Serviço de Lógica de Negócio
- Repositório EF Core
- Banco de Dados Relacional

🖼️ Diagrama visual: ver imagem anexada ao projeto

![](./assets/c4model.jpg)

---

## 💡 Diferenciais

- Projeto documentado com Swagger
- Implementação desacoplada com Injeção de Dependência
- Estrutura modularizada e escalável
- Códigos organizados por responsabilidade (SRP - SOLID)

---

## ✅ Requisitos Atendidos

- ✅ API REST com endpoints CRUD
- ✅ Padrão MVC aplicado
- ✅ Diagrama C4 entregue
- ✅ Explicação dos componentes
- ✅ Persistência implementada com EF Core
- ✅ Organização de pastas clara
- ✅ (Opcional) Código pode ser entregue via GitHub

---

## 🔗 Link do Projeto (opcional)

Caso deseje: [https://github.com/vitor-itsolution/arquiteto-software-desafio-final](https://github.com/vitor-itsolution/arquiteto-software-desafio-final)

