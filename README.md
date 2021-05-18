# DOOT

(Yes it's another TODO app)

## About

Doot is a TODO API that is built as a display piece to showcase good project and build architecture.

## Architecture

### Backend

- Dockerized .NET 5 API 
- Auth0 for authentication as a service
- Docker Compose for service management
- Traefik as reverse proxy (running as Docker service)
- PostgreSQL
- EF Core / Dapper as ORM
- DbUp library for Database migrations 
- XUnit / Moq for testing (TODO)
- Github actions for CI/CD (TODO)
- DigitalOcean for hosting

### Clients

- Typescript Command Line Interace (coming soon!)
- React / Typescript web app

## Usage

### Helpful Commands

Launch API
```shell
docker-compose up --build
```

Migrate DB
```shell
docker-compose -f docker-compose.migrate.yml build migrate
docker-compose -f docker-compose.migrate.yml run migrate
```

Teardown Architecture and DB
```shell
docker-compose down --rmi all --volumes
```

Launch Interactive Postgres Shell
```shell
docker exec -it DATABASE psql -U postgres -d doot
```

