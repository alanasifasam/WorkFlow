# WorkFlow.Vacation API

API para gerenciamento de pedidos de f�rias, constru�da com .NET 7, arquitetura hexagonal, e seguindo boas pr�ticas de seguran�a e testes.

---

## Tecnologias Utilizadas

- **.NET 7**
- **Arquitetura Hexagonal** (Separa��o de Application, Core e Infrastructure)
- **Entity Framework Core** (SQLite como banco de dados)
- **AutoMapper** (mapeamento entre entidades e modelos)
- **FluentValidation** (valida��o de modelos)
- **JWT Authentication** (seguran�a com tokens)
- **xUnit + Moq** (testes unit�rios)
- **Swagger** (documenta��o da API)
- **Docker** (para containeriza��o da aplica��o)

---

## Estrutura do Projeto

- **Core**: Entidades, enums e interfaces.
- **Application**: Servi�os, modelos (Input/Output) e regras de neg�cio.
- **Infrastructure**: Persist�ncia, reposit�rios e autentica��o.
- **API**: Camada de apresenta��o, controllers e configura��o do JWT.

---

## Configura��o de Seguran�a (JWT)

A API utiliza **JWT (JSON Web Tokens)** para autentica��o:


- Tokens assinados com **HMAC SHA256** (SymmetricSecurityKey).
- Rejei��o de tokens inv�lidos ou expirados.

## Testes Unit�rios

O projeto cont�m testes unit�rios para os servi�os usando xUnit e Moq.

Executar todos os testes:

dotnet test WorkFlow.Vacation.Tests

## Documenta��o da API

Swagger API:
Dispon�vel em http://localhost:5000/swagger/index.html

## Banco de Dados

SQLite como banco principal

Migrations gerenciadas com Entity Framework Core

**Criar migration**

dotnet ef migrations add NomeDaMigration -s WorkFlow.Vacation.API -p WorkFlow.Vacation.Infrastructure

**Atualizar banco**

dotnet ef database update -s WorkFlow.Vacation.API -p WorkFlow.Vacation.Infrastructure

Executando com Docker

Build da imagem: docker build -t workflow-vacation:latest .

docker run -d -p 5000:80 --name workflow-vacation workflow-vacation:latest


## Boas Pr�ticas Implementadas

Arquitetura Hexagonal: separa��o clara entre dom�nio, aplica��o e infraestrutura

Seguran�a JWT: tokens seguros, valida��o de emissor e expira��o

Valida��o com FluentValidation: garante integridade dos dados de entrada

Testes unit�rios: asseguram consist�ncia da l�gica de neg�cio

Documenta��o Swagger: facilita consumo e teste da API
