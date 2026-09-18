# API de Pedidos — Trabalho 1

Projeto incremental da disciplina **Desenvolvimento de Sistemas Distribuídos**. Primeira entrega: aplicação de Pedidos + banco PostgreSQL, executando como componentes separados.

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

.NET 8 · ASP.NET Core Web API · Entity Framework Core + Npgsql · PostgreSQL 16 · Docker / Docker Compose

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

| Método | Rota | Descrição |
|---|---|---|
| `POST` | `/Order` | Cria pedido |
| `GET` | `/Order` | Lista pedidos |
| `GET` | `/Order/{id}` | Consulta pedido (200 / 404) |
| `PATCH` | `/Order/{id}` | Atualiza pedido |
| `PATCH` | `/Order/{id}/status` | Altera apenas o status |
| `DELETE` | `/Order/{id}` | Remove pedido |
| `GET` | `/Health` | Health check (`{"status":"ok"}`) |

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

## Como executar

1. Crie um `.env` na raiz do projeto:
```env
POSTGRES_DB=pedido_np1
POSTGRES_USER=postgres
POSTGRES_PASSWORD=escolha_uma_senha
POSTGRES_PORT=5432
API_PORT=8080
```

2. Suba o ambiente:
```bash
docker compose up --build
```

A API aplica as migrations automaticamente. Acesse em `http://localhost:8080` (Swagger em `/swagger`).

## Critérios mínimos atendidos

- [x] `docker compose up` inicia aplicação e banco
- [x] `POST /Order` persiste um pedido
- [x] `GET /Order/{id}` e `GET /Order` recuperam os dados persistidos
- [x] `GET /Health` confirma que a aplicação está operacional
- [x] Reiniciar a API ou o banco não apaga os pedidos (dados no volume `pgdata`)
- [x] Configuração por variável de ambiente — nenhuma credencial fixa no código
