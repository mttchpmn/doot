FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Database/Database.csproj", "Database/"]
RUN dotnet restore "Database/Database.csproj"
COPY . .
WORKDIR "/src/Database"
RUN dotnet build "Database.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Database.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Database.dll"]
