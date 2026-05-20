# STUDY-GUIDED-RJWALKS
A guided project to study and practice the building of an ASP.NET Core Web API with Entity Framework Core, SQL Server, Authentication, Authorization 

# 🇳🇿 NZ Walks API - ASP.NET Core Web API (.NET 8)

## 🛠️ Tech Stack & Tools

* **Framework:** .NET 8 (ASP.NET Core Web API)
* **Language:** C# (Asynchronous programming using `async/await`)
* **Data Persistence:** Entity Framework Core (EF Core) with Code-First Migrations
* **Database:** SQL Server
* **Security & Auth:** JSON Web Tokens (JWT) & ASP.NET Core Identity
* **Object Mapping:** AutoMapper
* **API Documentation & Testing:** Swagger UI & Postman

---

## 🏗️ Design Patterns & Best Practices

* **Repository Pattern:** Decoupling data access logic from API controllers to guarantee testability, flexibility, and cleaner code.
* **Separation of Concerns (Domain vs DTOs):** Utilizing Data Transfer Objects (DTOs) to secure domain models and control exposure of sensitive information to the clients.
* **Dependency Injection (DI):** Leveraging native .NET inversion of control container for architectural modularity.
* **Model Validation:** Enforcing robust request validation logic to preserve data integrity.

---

## 🚀 Core Features

### 🔹 Full CRUD Operations
* Complete Create, Read, Update, and Delete operations for both **Regions** and **Walks**.

### 🔹 Advanced Query Capabilities
* **Filtering:** Dynamic, property-based query lookups.
* **Sorting:** Run-time configurable sorting directions (ascending/descending).
* **Pagination:** Server-side pagination controls to optimize throughput and response times.

### 🔹 Enterprise Security Model
* **JWT Authentication:** Server-generated cryptographic security tokens for stateless client verification.
* **ASP.NET Core Identity:** Built-in membership management to easily register users and manage profiles.
* **Role-Based Authorization:** Strict granular endpoint control (e.g., read-only access for `Reader` role vs full write access for `Writer` role).

---

## 🛣️ Endpoint Overview

Below are the primary routes exposed by the API (documented and testable via Swagger UI):

| Method | Endpoint | Description | Access Control |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/auth/register` | Register a new application user | Public |
| **POST** | `/api/auth/login` | Authenticate user and retrieve JWT Token | Public |
| **GET** | `/api/regions` | Retrieve regions (Supports Filtering, Sorting, Pagination) | Authorized (`Reader`/`Writer`) |
| **POST** | `/api/regions` | Add a new region into the database | Authorized (`Writer` only) |
| **GET** | `/api/walks` | Retrieve trails (Supports Filtering, Sorting, Pagination) | Authorized (`Reader`/`Writer`) |
| **PUT** | `/api/walks/{id}` | Modify attributes of a specific trail | Authorized (`Writer` only) |
| **DELETE** | `/api/walks/{id}` | Permanently delete a trail | Authorized (`Writer` only) |

---

=====================================================================================================================================================================================================================

## 🛠️ Tecnologias e Ferramentas Utilizadas

*   **Framework:** .NET 8 (ASP.NET Core Web API)
*   **Linguagem:** C# (Asynchronous Programming com `async/await`)
*   **Persistência de Dados:** Entity Framework Core (EF Core) com Migrations
*   **Banco de Dados:** SQL Server
*   **Segurança & Autenticação:** JWT (JSON Web Tokens) & ASP.NET Core Identity
*   **Mapeamento de Objetos:** AutoMapper
*   **Documentação & Testes:** Swagger UI & Postman

---

## 🏗️ Padrões de Projeto & Boas Práticas

*   **Repository Pattern:** Desacoplamento da lógica de persistência de dados dos controladores, facilitando a manutenção e a criação de testes.
*   **Separação de Conceitos (Domain vs. DTOs):** Uso de Data Transfer Objects (DTOs) para proteger as entidades de domínio e expor apenas os dados necessários para o cliente.
*   **Injeção de Dependência:** Utilização nativa do ecossistema .NET para garantir baixo acoplamento.
*   **Validação de Dados:** Implementação de validações robustas para garantir a integridade dos dados antes de processar as requisições.

---

## 🚀 Principais Funcionalidades

### 🔹 Operações CRUD Completas
*   Gerenciamento completo (Criação, Leitura, Atualização e Deleção) de **Regiões** e **Trilhas (Walks)**.

### 🔹 Recursos Avançados de Listagem
*   **Filtragem (Filtering):** Busca refinada de dados com base em propriedades específicas.
*   **Ordenação (Sorting):** Organização dinâmica dos resultados (crescente/decrescente).
*   **Paginação (Pagination):** Controle de paginação para otimizar a performance e o tráfego de dados na rede.

### 🔹 Segurança & Controle de Acesso
*   **Autenticação JWT:** Geração e validação de tokens JWT para autenticar os clientes da API.
*   **ASP.NET Core Identity:** Sistema completo para registro de novos usuários e gerenciamento de perfis.
*   **Autorização Baseada em Regras (Role-Based Authorization):** Restrição de endpoints (ex: apenas usuários com a role `Writer` podem criar ou editar dados, enquanto usuários `Reader` possuem acesso apenas de leitura).

---

## 🛣️ Estrutura de Endpoints (Resumo)

Abaixo estão as principais rotas expostas pela API (documentadas e testáveis via Swagger UI):

| Método | Endpoint | Descrição | Requisito de Acesso |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/auth/register` | Registra um novo usuário no sistema | Público |
| **POST** | `/api/auth/login` | Autentica o usuário e retorna o Token JWT | Público |
| **GET** | `/api/regions` | Lista as regiões (Suporta Filtro, Ordenação e Paginação) | Autenticado (`Reader`/`Writer`) |
| **POST** | `/api/regions` | Cria uma nova região | Apenas `Writer` |
| **GET** | `/api/walks` | Lista as trilhas (Suporta Filtro, Ordenação e Paginação) | Autenticado (`Reader`/`Writer`) |
| **PUT** | `/api/walks/{id}` | Atualiza os dados de uma trilha específica | Apenas `Writer` |
| **DELETE** | `/api/walks/{id}` | Remove uma trilha do banco de dados | Apenas `Writer` |

---
