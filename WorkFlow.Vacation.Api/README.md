# WorkFlow.Vacation API

API para gerenciamento de pedidos de férias, construída com .NET 7, arquitetura hexagonal, e seguindo boas práticas de segurança e testes.

---

## Tecnologias Utilizadas

- **.NET 7**
- **Arquitetura Hexagonal** (Separação de Application, Core e Infrastructure)
- **Entity Framework Core** (SQLite como banco de dados)
- **AutoMapper** (mapeamento entre entidades e modelos)
- **FluentValidation** (validação de modelos)
- **JWT Authentication** (segurança com tokens)
- **xUnit + Moq** (testes unitários)
- **Swagger** (documentação da API)
- **Docker** (para containerização da aplicação)

---

## Estrutura do Projeto

- **Core**: Entidades, enums e interfaces.
- **Application**: Serviços, modelos (Input/Output) e regras de negócio.
- **Infrastructure**: Persistência, repositórios e autenticação.
- **API**: Camada de apresentação, controllers e configuração do JWT.

---

## Configuração de Segurança (JWT)

A API utiliza **JWT (JSON Web Tokens)** para autenticação:


- Tokens assinados com **HMAC SHA256** (SymmetricSecurityKey).
- Rejeição de tokens inválidos ou expirados.

## Testes Unitários

O projeto contém testes unitários para os serviços usando xUnit e Moq.

Executar todos os testes:

dotnet test WorkFlow.Vacation.Tests

## Documentação da API

Swagger API:
Disponível em http://localhost:5000/swagger/index.html

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


## Boas Práticas Implementadas

Arquitetura Hexagonal: separação clara entre domínio, aplicação e infraestrutura

Segurança JWT: tokens seguros, validação de emissor e expiração

Validação com FluentValidation: garante integridade dos dados de entrada

Testes unitários: asseguram consistência da lógica de negócio

Documentação Swagger: facilita consumo e teste da API
