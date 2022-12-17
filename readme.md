# CRM Educacional

Este é um projeto de gestão de relacionamento com o cliente (CRM) para a empresa CRM Educacional, desenvolvido como um desafio técnico para a vaga de desenvolvedor. O projeto permite:

- Cadastrar leads (candidatos) com validação de CPF
- Cadastrar novos cursos
- Cadastrar novas inscrições, que são compostas por um candidato e um curso. Um candidato pode ter mais de uma inscrição.

## Requisitos

Para executar este projeto, é necessário ter o seguinte software instalado em sua máquina:

- [.NET Core 6.0](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) ou [Visual Studio Code](https://code.visualstudio.com/)

## Configuração

1. Faça o clone deste repositório para sua máquina local.
2. Abra o projeto no Visual Studio ou Visual Studio Code.
3. No arquivo appsettings.json, configure a string de conexão com o banco de dados.
4. No terminal do Visual Studio Code ou na janela do Gerenciador de Pacotes do Visual Studio, execute o comando `dotnet restore` para instalar as dependências do projeto.
5. Execute o comando `dotnet ef database update` para criar o banco de dados e aplicar as migrações.

## Execução

Para iniciar a aplicação, basta pressionar F5 no Visual Studio ou executar o comando `dotnet run` no terminal do Visual Studio Code.

## Tecnologias

Este projeto foi desenvolvido com as seguintes tecnologias:

- [ASP.NET Core 6.0](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core 6.0](https://docs.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server)
