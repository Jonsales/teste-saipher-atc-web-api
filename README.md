# Teste.Saipher.ATC

Projeto criado em .NET Core 3.1

## Documentação de API

Existe um arquivo com todas os end-points que pode se exportar e verificar no Postman;

## Criar Base de Dados

Realizar query no SQL -> CREATE DATABASE TESTE_SAIPHER_ATC;;
Ao criar a Database, verifique a connectionString e altere no o valor da chave ConnectionStrings-> DefaultConnection no documento Json, localizado em 1 - Presentation / Teste.Saipher.ATC.WebAPI 

## Criar tabelas

Rodar Script no Update-Database no Package Manager Console, com o Default Project selecionado no 4 - Infra/4.1 - Data/Teste.Saipher.ATC.Data/