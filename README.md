# Todo List APIProject in .NET

## Descrição Geral
O back-end deste projeto é uma API RESTful desenvolvida em ASP.NET Core, com a linguagem C#, utilizando Entity Framework para a interação com um banco de dados PostgreSQL. A API gerencia as operações CRUD para as tarefas e fornece um serviço robusto para o front-end.

## Funcionalidades Principais

CRUD de Tarefas: A API permite criar, ler, atualizar e excluir tarefas através dos seguintes endpoints:

- GET /api/Tasks: Retorna todas as tarefas.
- POST /api/Tasks: Cria uma nova tarefa.
- PATCH /api/Tasks/{id}: Atualiza uma tarefa existente.
- DELETE /api/Tasks/{id}: Remove uma tarefa.

## Estrutura do Projeto

A comunicação com o banco de dados é gerenciada pelo TodoContext, que realiza as operações de banco de dados usando Entity Framework. As migrações são utilizadas para gerenciar o esquema do banco de dados.

## Docker

O projeto é containerizado usando Docker, o que permite uma implementação e escalabilidade simplificadas. O Dockerfile está configurado para construir e executar a aplicação ASP.NET Core.

## Execução e Instalação do Projeto

Para configurar o projeto localmente, siga as etapas abaixo:

Clone o repositório:

git clone [Repository Back End](https://github.com/larissabpaz/TodoAngularApi)

Instale as dependências: `dotnet restore`

Aplique as Migrations: `dotnet ef database update`

Execute o Projeto: `dotnet run`

## Execução no Docker

Para construir a imagem Docker, utilize o comando `docker build -t nome-da-imagem:tag .` na raiz do projeto.
Para executar os contêineres, utilize o comando `docker-compose up`. Isso iniciará a API junto com o banco de dados PostgreSQL.