FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["InventoryWorker/InventoryWorker.csproj", "InventoryWorker/"]
COPY ["InventoryWorker.Application/InventoryWorker.Application.csproj", "InventoryWorker.Application/"]
COPY ["InventoryWorker.Infrastructure/InventoryWorker.Infrastructure.csproj", "InventoryWorker.Infrastructure/"]

RUN dotnet restore "InventoryWorker/InventoryWorker.csproj"

COPY . .

WORKDIR "/src/InventoryWorker"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "InventoryWorker.dll"]
