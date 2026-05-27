# RealtimePokerBackend

ASP.NET Core 기반의 실시간 포커 백엔드 학습 프로젝트입니다.

JWT 인증, EF Core ORM, SQLite DB, Swagger API 문서화를 적용하여
실제 서비스 백엔드 구조를 학습하고 구현하는 것을 목표로 합니다.

---

## Tech Stack

- ASP.NET Core Web API (.NET 10)
- C#
- Entity Framework Core
- SQLite
- JWT Authentication
- BCrypt Password Hashing
- Swagger / OpenAPI
- SignalR
- WebSocket

---

## Features

### Authentication

- JWT 기반 로그인 인증
- BCrypt 기반 비밀번호 해시 저장
- Authorization 보호 API
- Swagger JWT 인증 테스트 지원

### Player API

- Player CRUD API
- EF Core 기반 DB 저장
- DTO Validation 적용
- SQLite 영구 저장

### Real-time Communication

- SignalR 기반 WebSocket 통신
- Poker Room Join / Leave
- 실시간 Broadcast Message
- Group 기반 Room 관리

### Database

- EF Core Migration 적용
- SQLite Database 연동

---

## Project Structure

```txt
RealtimePokerBackend

├── Controllers
│   ├── AuthController.cs
│   └── PlayersController.cs
│
├── Services
│   └── PlayerService.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Models
│   ├── Player.cs
│   └── User.cs
│
├── DTOs
│
└── Program.cs
```

---

## API Endpoints

### Auth

#### Login

POST `/api/Auth/login`

Request

```json
{
  "userName": "admin",
  "password": "1234"
}
```

Response

```json
{
  "token": "JWT_TOKEN"
}
```

---

### Players

#### Get Players

GET `/api/Players`

Authorization Required

```txt
Bearer JWT_TOKEN
```

Example Response

```json
[
  {
    "id": 1,
    "username": "player1",
    "chips": 1000
  },
  {
    "id": 2,
    "username": "player2",
    "chips": 2000
  }
]
```

---

## Run Project

### Install Dependencies

```bash
dotnet restore
```

### Run Server

```bash
dotnet run
```

---

## Database Migration

Create Migration

```bash
dotnet ef migrations add InitialCreate
```

Apply Migration

```bash
dotnet ef database update
```

---

## Authentication Flow

```txt
Login
↓
JWT Token 발급
↓
Swagger Authorize
↓
Authorization Header 적용
↓
Protected API 접근
```

---

## Future Improvements

- SignalR WebSocket 실시간 통신
- Role 기반 Authorization
- Redis Cache
- Docker 배포
- AWS / Azure Cloud 환경 적용

---

## Learning Goals

- ASP.NET Core Web API 구조 이해
- EF Core ORM 및 Migration 경험
- JWT 기반 인증/인가 구현
- 실무형 백엔드 계층 구조 학습
- 실시간 서비스(WebSocket) 확장 기반 구축