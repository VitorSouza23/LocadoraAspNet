# LocadoraAspNet

## Sobre
Uma API simples para demostração de CRUD no contexto de uma locadora de fimes.

## Funcionalidades
As funcionalidades se concentram em operações de CRUD em três principais domínios:
- Gênero de filme
- Filmes
- Locação de Filmes

## Tecnologias
- ASP.NET Core (.NET 5)
  - MediatoR
  - AutomMapper
  - Fluent Validentions
  - EF Core
- SQL Server (Base de dados)
- Doker (Para rodar a aplicação)

## Como rodar localmente
Após clonar o repositório localmente, abra a raiz do projeto e execute os comandos do docker compose:
- Build: `docker-compose build`
- Rodar: `docker-composec up`

A aplicação ficará disponível na url: `http://localhost:5000/index.html`

