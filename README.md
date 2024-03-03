# APICatalogo-CSharp-Macoratti

- Instalação de pacotes:
  - Pomelo.EntityFrameworkeCore.MySql
  - Microsoft.EntityFrameworkeCore.Design
  - Microsoft.AspNetCore.OpenApi
 
- ENTITY FRAMEWORK (comandos para no terminal)
  - **dotnet tool install --global dotnet-ef**
    ou
  - **dotnet tool update --global dotnet-ef**

- Criação de MIGRATIONS e config das tabelas do BANCO DE DADOS
  - Criação das migrations:
    - **dotnet ef migrations add "nome da migration (sem as áspas)"**
  - Criação ou edição das tabelas no banco de dados
    - **dotnet ef database update**
