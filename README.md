# RealtimePokerBackend

ASP.NET Core 기반 Poker Backend 학습 및 포트폴리오 프로젝트 입니다.

## 기술 스택

- ASP.Net Core (.Net 10)
- C#
- Swagger
- Dependency Injection (DI)
- REST_API

## 프로젝트 구조

```txt
Controllers
Services
Models
DTOs
Data
Auth
```

## 구현 기능

### Player API

- Player 조회 (GET)
- Player 생성 (POST)
- Player 수정 (PUT)
- Player 삭제 (DELETE)

### Validation

- DataAnnotations 기반 요청 데이터 검증
- 자동 400 Bad Request 응답 처리

### Architecture

- Controller / Service Layer 분리
- Dependency Injection 적용

## API Endpoints

GET

```txt
/api/Players
```

POST

```txt
/api/Players
```

PUT

```txt
/api/Players/{id}
```

DELETE

```txt
/api/Players{id}
```

## 실행 방법

```txt
dotnet run
```

Swagger 접속

```txt
http://localhost:5114/swagger
```