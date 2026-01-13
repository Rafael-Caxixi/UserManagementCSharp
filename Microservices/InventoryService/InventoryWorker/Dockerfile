FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/InventoryWorker/InventoryWorker.csproj", "src/InventoryWorker/"]
COPY ["src/InventoryWorker.Application/InventoryWorker.Application.csproj", "src/InventoryWorker.Application/"]
COPY ["src/InventoryWorker.Infrastructure/InventoryWorker.Infrastructure.csproj", "src/InventoryWorker.Infrastructure/"]

RUN dotnet restore "src/InventoryWorker/InventoryWorker.csproj"

COPY . .

WORKDIR "/src/src/InventoryWorker"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InventoryWorker.dll"]
