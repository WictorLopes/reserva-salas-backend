# 🏢 Reserva de Salas — Backend (C# .NET 8 + Entity Framework)

Este repositório contém o backend do sistema de gerenciamento de reservas de salas.
Foi desenvolvido em C# com .NET 8, seguindo boas práticas de arquitetura, organização, versionamento e camadas.

## 🚀 Como rodar a aplicação
### 1️⃣ Requisitos
```bash
.NET SDK 8.0+
SQL Server ou PostgreSQL
```

- Verifique sua versão:
```bash
dotnet --version
```

### 2️⃣ Clonar o repositório
```bash
git clone https://github.com/WictorLopes/reserva-salas-backend
cd ReservaSalas.Api
```

* Para uma experiência completa, clone e rode também o frontend do projeto disponível em:
```bash
https://github.com/WictorLopes/reserva-salas-frontend
```

### 3️⃣ Configurar o banco de dados

No arquivo appsettings.json, configure a ConnectionString:

Exemplo com PostgreSQL:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ReservaSalasDB;Username=postgres;Password=123;"
}
```

### 4️⃣ Aplicar as Migrations
```bash
dotnet ef database update
```

- Caso não existam migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Rodar a API
```bash
dotnet run
```

### A API estará disponível em:
```bash
http://localhost:5243
```

- E o Swagger em:
```bash
http://localhost:5243/swagger
```

## 🧩 Tecnologias Utilizadas e Justificativas
✅ C# + .NET 8

- Framework moderno, robusto e com alta performance.

- Excelente suporte a APIs REST

- Multiplataforma

- Ideal para aplicações de médio e grande porte

✅ Entity Framework Core

- ORM escolhido para simplificar o acesso ao banco de dados.

- Migrations automáticas

- Padronização de modelos e validações


## 📡 Endpoints principais

A API possui CRUD completo para:

- Localizações (Locations)

- Salas (Rooms)

- Reservas (Reservations)

### Exemplo (Rooms):

Método	Endpoint	Descrição
```bash
GET	/api/rooms ->	Lista todas as salas
POST	/api/rooms	-> Cria uma sala
GET	/api/rooms/{id}	-> Busca por ID
PUT	/api/rooms/{id}	-> Atualiza
DELETE	/api/rooms/{id} -> Remove
```

## 🧪 Padrões e Boas Práticas Adotadas

- Camadas separadas (Controller → Service → Repository)

- DTOs para entrada e saída de dados

- Validações server-side

- Injeção de Dependência (DI nativo do .NET)

- Convenções REST
