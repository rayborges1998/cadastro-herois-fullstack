# Cadastro de Heróis 🦸‍♀️🦸‍♂️

Projeto Fullstack desenvolvido como desafio técnico.
O sistema realiza um **CRUD de super-heróis**, permitindo cadastrar, editar, listar e visualizar heróis com seus respectivos superpoderes.

---

## Tecnologias Utilizadas

### Backend (.NET 6 ou 8)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper (opcional)
- CORS habilitado para acesso do Angular

### Frontend (Angular 16+)
- Angular standalone components
- Angular Router
- FormsModule (Template-driven)
- Bootstrap (opcional para estilo)

---

## Como rodar o projeto

### Pré-requisitos

- [.NET SDK 6 ou 8](https://dotnet.microsoft.com/download)
- [Node.js + NPM](https://nodejs.org)
- Angular CLI (`npm install -g @angular/cli`)
- SQL Server Local ou Azure (se não usar InMemory)

---

### Backend (.NET)

1. Navegue até a pasta do projeto back-end:
   
   cd CadastroHeroisAPI

A conexão com banco de dados está InMemory.

Executar:
dotnet run


Frontend (Angular)

Navegue até a pasta do front:
    cd CadastroHeroisFront

Instale as dependências:
    npm install

Rode o projeto:
    ng serve

Acesse:
http://localhost:4200

