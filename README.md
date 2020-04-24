# Teste.Saipher.ATC

Projeto criado em .NET Core 3.1

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:5000/`. The app will automatically reload if you change any of the source files.

## Criar Base de Dados

Realizar query no SQL -> CREATE DATABASE databasename;;
Ao criar a Database, verifique a connectionString e altere no o valor da chave ConnectionStrings-> DefaultConnection no documento Json, localizado em 1 - Presentation / Teste.Saipher.ATC.WebAPI 

## Criar tabelas

Rodar Script no Update-Database no Package Manager Console, com o Default Project selecionado no 4 - Infra/4.1 - Data/Teste.Saipher.ATC.Data/