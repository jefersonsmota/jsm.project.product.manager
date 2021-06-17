<div align="center" id="top"> 
  🛒🛒🛒

  &#xa0;

  <!-- <a href="https://project3pmybil.netlify.com">Demo</a> -->
</div>

<h1 align="center">Project 3pMYbIl</h1>

<p align="center">
  <img alt="Principal linguagem do projeto" src="https://img.shields.io/github/languages/top/jefersonsmota/Project.3pMYbIl?color=56BEB8">

  <img alt="Quantidade de linguagens utilizadas" src="https://img.shields.io/github/languages/count/jefersonsmota/Project.3pMYbIl?color=56BEB8">

  <img alt="Tamanho do repositório" src="https://img.shields.io/github/repo-size/jefersonsmota/Project.3pMYbIl?color=56BEB8">

  <img alt="Licença" src="https://img.shields.io/github/license/jefersonsmota/Project.3pMYbIl?color=56BEB8">

  <!-- <img alt="Github issues" src="https://img.shields.io/github/issues/jefersonsmota/Project.3pMYbIl?color=56BEB8" /> -->

  <!-- <img alt="Github forks" src="https://img.shields.io/github/forks/jefersonsmota/Project.3pMYbIl?color=56BEB8" /> -->

  <!-- <img alt="Github stars" src="https://img.shields.io/github/stars/jefersonsmota/Project.3pMYbIl?color=56BEB8" /> -->
</p>

<!-- Status -->

<!-- <h4 align="center"> 
	🚧  Project 3pMYbIl 🚀 Em construção...  🚧
</h4> 

<hr> -->

<p align="center">
  <a href="#dart-sobre">Sobre</a> &#xa0; | &#xa0; 
  <a href="#sparkles-funcionalidades">Funcionalidades</a> &#xa0; | &#xa0;
  <a href="#rocket-tecnologias">Tecnologias</a> &#xa0; | &#xa0;
  <a href="#white_check_mark-pré-requesitos">Pré requisitos</a> &#xa0; | &#xa0;
  <a href="#checkered_flag-começando">Começando</a> &#xa0; | &#xa0;
  <a href="#memo-licença">Licença</a> &#xa0; | &#xa0;
  <a href="https://github.com/jefersonsmota" target="_blank">Autor</a>
</p>

<br>

## :dart: Sobre ##

Website composto por uma tela de login (autenticando via api) e um CRUD de produtos.

## :sparkles: Funcionalidades ##

:heavy_check_mark: Login de usuário \
:heavy_check_mark: Listagem de produtos \
:heavy_check_mark: Criação/Adição de produtos \
:heavy_check_mark: Edição de produtos \
:heavy_check_mark: Exclusão de produtos 

## :rocket: Tecnologias ##

As seguintes ferramentas foram usadas na construção do projeto:

 - Sql Server 2019
 - C# .net 5
 - EntityFramework Core
 - Html, Css e javascript
 - Angular 12

## :white_check_mark: Pré requisitos ##

Antes de começar :checkered_flag:, você precisa ter instalados em sua maquina:
- [Git](https://git-scm.com)
- [Node](https://nodejs.org/en/) 
- [Angular](https://angular.io/)
- [Microsoft Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/) ou [.Net 5 Runtime](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- ou Para container com [Docker](https://hub.docker.com/r/microsoft/mssql-server-windows-express/)

## :checkered_flag: Começando ##

```bash
# Clone este repositório
$ git clone https://github.com/jefersonsmota/Project.3pMYbIl

# Entre na pasta
$ cd Project.3pMYbIl
```

### Banco de dados
1. Instale o Microsoft SQL Server 2019 ou superior
2. Crie base de dados e usuários para execução do projeto
3. Execute o script de criação das tabelas, presente no repositório.
```
 \SqlScripts
 ```



### API (Back-End)

1. Instale Visual Studio 2019 ou superior, ou somente o .Net Runtime 5.0
2. Abrar o projeto Web API do diretório \WebApi
3. Configure a string de conexão de acordo com a base de dados.
```json
...
"ConnectionStrings": {
    "DefaultConnection": "DATABASE_CONNECTION_STRING"
  },
  ...
```
4. Execute o projeto com o comando
```Powershell
dotnet run
```

### Web App (Front-End)
1. Instale o Node 14.x ou superior;
2. Instale o Framework Angular v12.x ou superior;
3. Adicione a URL referente a Web API ao arquivo de constants do projeto presente em:

```Bash
\WebNgFrontend\src\app\core\app.constants.ts
```

4. No diretório do projeto Front-End, execute o projeto com
```Bash
npm start
```

## :memo: Licença ##

Este projeto está sob licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.


Feito por <a href="https://github.com/jefersonsmota" target="_blank">Jeferson Mota</a>

&#xa0;

<a href="#top">Voltar para o topo</a>
