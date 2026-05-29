# RealtimePokerBackend

ASP.NET Core 기반의 실시간 포커 백엔드 학습 프로젝트입니다.

JWT 인증, EF Core ORM, MySQL DB, Redis Cache, SignalR(WebSocket), Docker 환경을 적용하여
실제 서비스형 실시간 Backend 구조를 학습하고 구현하는 것을 목표로 합니다.

---

## Tech Stack

* ASP.NET Core Web API (.NET 9)
* C#
* Entity Framework Core
* MySQL
* JWT Authentication
* BCrypt Password Hashing
* Swagger / OpenAPI
* SignalR
* WebSocket
* Redis
* Docker
* Docker Compose

---

## Features

### Authentication

* JWT 기반 로그인 인증
* BCrypt 기반 비밀번호 해시 저장
* Authorization 보호 API
* Swagger JWT 인증 테스트 지원

### Player API

* Player CRUD API
* EF Core 기반 DB 저장
* DTO Validation 적용
* MySQL 영구 저장

### Real-time Communication

* SignalR 기반 WebSocket 통신
* Poker Room Join / Leave
* 실시간 Broadcast Message
* Group 기반 Room 관리

### Database

* EF Core Migration 적용
* MySQL Database 연동
* Docker MySQL 환경 구성

### Cache

* Redis 기반 Player 조회 캐싱
* Cache Aside Pattern 적용
* Cache Invalidation 구현

### Docker

* Dockerfile 기반 컨테이너 이미지 생성
* Docker Compose 기반 Backend / Redis / MySQL 멀티 서비스 환경 구성

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
├── Hubs
│   └── PokerHub.cs
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

#### Register

POST `/api/Auth/register`

Request

```json
{
  "userName": "admin",
  "password": "1234"
}
```

---

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

### Run Docker Environment

```bash
docker compose up --build
```

---

## Database Migration

Create Migration

```bash
dotnet ef migrations add MigrationName
```

Apply Migration

```bash
dotnet ef database update
```

---

## Authentication Flow

```txt
Register
↓
BCrypt Password Hashing 저장
↓
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

## Cache Flow

```txt
Player Request
↓
Redis Cache 조회

Cache Hit
↓
Redis Response 반환

Cache Miss
↓
MySQL 조회
↓
Redis Cache 저장
↓
Response 반환
```

---

## Docker Environment

```txt
Docker Compose

├── Backend (ASP.NET Core API)
├── Redis (Distributed Cache)
└── MySQL (Persistent Database)
```

---

## Future Improvements

* Room State / Player Tracking 구현
* Matchmaking 시스템
* Role 기반 Authorization
* Distributed Scale Out 구조
* AWS / Azure Cloud 환경 적용

---

## Learning Goals

* ASP.NET Core Web API 구조 이해
* EF Core ORM 및 Migration 경험
* JWT 기반 인증/인가 구현
* SignalR(WebSocket) 실시간 통신 경험
* Redis Cache 및 Cache Aside Pattern 구현
* Docker 기반 멀티 서비스 환경 구성
* 실무형 Backend 계층 구조 학습
