# API de Pedidos — Trabalho 1

Projeto incremental da disciplina **Desenvolvimento de Sistemas Distribuídos**. Primeira entrega: aplicação de Pedidos + banco PostgreSQL, executando como componentes separados.

## Identificação dos Integrantes
```
Nome: Rafael Luna Machiavelli
RA: R017885
Turma: CC7P13
```

## Arquitetura

```
Cliente → API de Pedidos → PostgreSQL
```

- Cliente ↔ API: HTTP/JSON
- API ↔ Banco: protocolo PostgreSQL (Npgsql)
- Aplicação e banco em containers Docker separados, ligados por rede interna
- Dados do banco em volume Docker (`pgdata`) — sobrevivem a reinício de qualquer container

Camadas internas (mesmo processo/container):

```
Controller (API) → Service → Repository → PostgreSQL
```

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core + Npgsql
- PostgreSQL 16
- Docker / Docker Compose

## Modelo de dados — Pedido

| Campo | Descrição |
|---|---|
| `OrderId` | Identificador |
| `ClientName` | Cliente |
| `Address` | Endereço |
| `OrderDate` | Data de criação |
| `Products` | Itens do pedido (produto, quantidade, valor unitário) |
| `TotalOrderPrice` | Calculado pela aplicação |
| `OrderStatus` | `Criado` (padrão) · `Confirmado` · `Cancelado` |

## Endpoints

Base URL: `http://localhost:8000` </br>
Swagger disponível em `http://localhost:8000/swagger`.

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/Order` | Cria pedido |
| `GET` | `/Order` | Lista pedidos |
| `GET` | `/Order/{id}` | Consulta pedido (200 / 404) |
| `PATCH` | `/Order/{id}` | Atualiza pedido |
| `PATCH` | `/Order/{id}/status` | Altera apenas o status |
| `DELETE` | `/Order/{id}` | Remove pedido (soft delete) |
| `GET` | `/Health` | Health check (`{"status":"Ok"}`) |

**Exemplo — `POST /Order`:**
```json
{
  "clientName": "Maria",
  "address": "Rua A, 123",
  "products": [
    { "productName": "Caneta", "productQuantity": 2, "productPrice": 3.50 }
  ]
}
```
**Exemplo - `GET /Order/{id}`:** 
- é adicionado 4 campos, setando data da criação do pedido (data/hora atual), valor total por produto, o status do pedido (automaticamente como criado após a criação do pedido) e o valor total do pedido.
```json
{
  "clientName": "Maria",
  "address": "Rua A, 123",
  "orderDate": "2026-09-19T16:34:44.67438Z",
  "products": [
    { "productName": "Caneta", "productQuantity": 2, "productPrice": 3.50, "totalPrice": 7.0 },
    { "productName": "Estojo", "productQuantity": 1, "productPrice": 10.0, "totalPrice": 10.0 }
  ],
  "orderStatus": "Criado",
  "totalOrderPrice": 17.0
}
```

## Como executar

```bash
git clone <URL_DO_REPOSITORIO>
cd <NOME_DO_REPOSITORIO>
docker compose up -d --build
```

Não é necessário nenhum passo manual adicional — a aplicação aplica as migrations do banco automaticamente ao subir, e as credenciais do PostgreSQL já têm valores padrão definidos no próprio `docker-compose.yml` (sem depender de um arquivo `.env`).

Ao final, a API estará disponível em `http://localhost:8000`.

> Caso queira customizar as credenciais do banco localmente, é possível criar um `.env` na raiz do projeto com `POSTGRES_DB`, `POSTGRES_USER` e `POSTGRES_PASSWORD` — esses valores sobrescrevem os defaults, mas não são obrigatórios para a aplicação funcionar.

## Serviços do `docker-compose.yml`

| Serviço | Descrição |
|---|---|
| `pedidos` | API de Pedidos (build a partir do `Dockerfile`) |
| `postgres` | Banco de dados PostgreSQL 16 |

## Critérios mínimos atendidos

- ✅ `docker compose up -d --build` inicia aplicação e banco sem passos manuais
- ✅ `POST /Order` persiste um pedido
- ✅ `GET /Order/{id}` e `GET /Order` recuperam os dados persistidos
- ✅ `GET /Health` confirma que a aplicação está operacional
- ✅ Reiniciar a API ou o banco não apaga os pedidos (dados no volume `pgdata`)
- ✅ Configuração por variável de ambiente — nenhuma credencial fixa no código
