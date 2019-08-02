docker-compose -f local-db.yml up
dotnet ef dbcontext scaffold "Host=localhost;Database=ef-tips;Username=postgres;Password=postgres@123" Npgsql.EntityFrameworkCore.PostgreSQL