# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj da API
COPY UserManagement.Api/UserManagement.Api.csproj UserManagement.Api/

# Copia os csproj das dependências (IMPORTANTE)
COPY UserManagement.Application/UserManagement.Application.csproj UserManagement.Application/
COPY UserManagement.Domain/UserManagement.Domain.csproj UserManagement.Domain/
COPY UserManagement.Infrastructure/UserManagement.Infrastructure.csproj UserManagement.Infrastructure/

# Restore
RUN dotnet restore UserManagement.Api/UserManagement.Api.csproj

# Copia todo o código
COPY . .

# Publish
WORKDIR /src/UserManagement.Api
RUN dotnet publish -c Release -o /app/publish

# Final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Api.dll"]
