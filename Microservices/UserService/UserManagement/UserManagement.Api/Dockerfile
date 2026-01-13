# ========= Runtime =========
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# ========= Build =========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["UserManagement.Api/UserManagement.Api.csproj", "UserManagement.Api/"]
COPY ["UserManagement.Application/UserManagement.Application.csproj", "UserManagement.Application/"]
COPY ["UserManagement.Infrastructure/UserManagement.Infrastructure.csproj", "UserManagement.Infrastructure/"]
COPY ["UserManagement.Domain/UserManagement.Domain.csproj", "UserManagement.Domain/"]

RUN dotnet restore "UserManagement.Api/UserManagement.Api.csproj"

COPY . .

WORKDIR "/src/UserManagement.Api"
RUN dotnet publish -c Release -o /app/publish

# ========= Final =========
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.Api.dll"]
